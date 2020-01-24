import { build, Token, routeParamSelector, routeParamIdSelector, compareStrings, compareNumbers } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, interval, combineLatest } from 'rxjs';
import { map, distinctUntilChanged, take } from 'rxjs/operators';

import { CurrentUser, Contestants, Contestant, User, Users, Rankings, Ranking } from './models';

export function activeUserSelector(store: Store<any>): Observable<User> {
  return combineLatest(store.select('users'), routeParamIdSelector(store, 'userId'), (users, id) => users.get(id));
}

export function activeUserNameSelector(store: Store<any>): Observable<string> {
  return activeUserSelector(store).pipe(
    map(x => x.firstName),
    distinctUntilChanged()
  );
}

export function activeUserIdSelector(store: Store<any>): Observable<number> {
  return activeUserSelector(store).pipe(
    map(x => x.id),
    distinctUntilChanged()
  );
}

export function authenticatedSelector(store: Store<any>): Observable<boolean> {
  return currentUserSelector(store).pipe(
    map(user => user.authenticated),
    take(1)
  );
}

export function authTokenSelector(store: Store<any>): Observable<string> {
  return currentUserSelector(store).pipe(
    map(user => {
      const token: Token = user && user.token ? build(Token, user.token) : new Token();
      return token.toString();
    })
  );
}

export function contestantsSelector(store: Store<any>): Observable<Contestants> {
  return store.select('contestants');
}

export function contestantsArraySelector(store: Store<any>): Observable<Contestant[]> {
  return contestantsSelector(store).pipe(
    map(x => x.asArray)
  );
}

export function contestantSelector(store: Store<any>): Observable<Contestant> {
  return combineLatest(contestantsSelector(store), routeParamIdSelector(store, 'contestantId'), currentUserRankingsSelector(store), (contestants, id, rankings) => {
    const ranking = build(Ranking, rankings.find(x => x.contestantSeasonId === id));
    return build(Contestant, contestants.get(id), {
      userNotes: ranking.notes,
      userRank: ranking.rank,
      userRankingId: ranking.id
    });
  });
}

export function currentTimeSelector(store: Store<any>): Observable<Date> {
  return interval(60000).pipe(
    map(x => {
      const d = new Date();
      d.setTime(d.getTime() + 60 * 1000);
      return d;
    })
  );
}

export function redirectToSelector(store: Store<any>): Observable<string> {
  return routeParamSelector(store, 'redirectTo', 'dashboard').pipe(distinctUntilChanged());
}

export function currentUserSelector(store: Store<any>): Observable<CurrentUser> {
  return store.select('currentUser').pipe(map(user => {
    return build(CurrentUser, user);
  }));
}

export function currentUserIdSelector(store: Store<any>): Observable<number> {
  return currentUserSelector(store).pipe(
    map(x => x.id),
    distinctUntilChanged()
  );
}

export function userNameSelector(store: Store<any>): Observable<string> {
  return currentUserSelector(store).pipe(
    map(x => x.fullName),
    distinctUntilChanged()
  );
}

export function activeDateSelector(store: Store<any>): Observable<Date> {
  return routeParamSelector(store, 'date').pipe(map(x => (x ? new Date(x) : new Date())));
}

export function usersSelector(store: Store<any>): Observable<Users> {
  return store.select('users');
}

export function rankingsSelector(store: Store<any>): Observable<Rankings> {
  return store.select('rankings');
}

export function activeUserRankingsSelector(store: Store<any>): Observable<Ranking[]> {
  return combineLatest(rankingsSelector(store), activeUserIdSelector(store), (rankings, userId) => {
    return rankings.asArray.filter(x => x.userId === userId);
  });
}

export function activeUserContestantRankingsSelector(store: Store<any>): Observable<Ranking[]> {
  return combineLatest(activeUserRankingsSelector(store), contestantsArraySelector(store), (rankings, contestants) => {
    return contestants.map(x => {
      const r = build(Ranking, rankings.find(y => y.contestantSeasonId === x.id));
      return build(Ranking, r, {
        contestantAge: x.age,
        contestantHometown: x.hometown,
        contestantName: x.name,
        contestantProfession: x.profession,
        contestantSeasonId: x.id,
        contestantSrc: x.src,
        contestantEliminated: x.eliminated,
        points: Rankings.CalculatePoints(x.finish, r.rank + 1)
      });
    }).sort((a, b) => compareNumbers(a.rank, b.rank)).map((x, i) => build(Ranking, x, { order: i }));
  });
}

export function currentUserRankingsSelector(store: Store<any>): Observable<Ranking[]> {
  return combineLatest(rankingsSelector(store), currentUserIdSelector(store), (rankings, userId) => {
    return rankings.asArray.filter(x => x.userId === userId);
  });
}

export function currentUserContestantRankingsSelector(store: Store<any>): Observable<Ranking[]> {
  return combineLatest(currentUserRankingsSelector(store), contestantsArraySelector(store), (rankings, contestants) => {
    return contestants.map(x => build(Ranking, rankings.find(y => y.contestantSeasonId === x.id), {
      contestantAge: x.age,
      contestantHometown: x.hometown,
      contestantName: x.name,
      contestantProfession: x.profession,
      contestantSeasonId: x.id,
      contestantSrc: x.src,
      contestantEliminated: x.eliminated
    })).sort((a, b) => compareNumbers(a.rank, b.rank)).map((x, i) => build(Ranking, x, { order: i }));
  });
}

export function allRankingsSelector(store: Store<any>): Observable<Ranking[]> {
  return rankingsSelector(store).pipe(
    map(x => x.asArray)
  );
}

export function allUsersSelector(store: Store<any>): Observable<User[]> {
  return combineLatest(usersSelector(store), currentUserIdSelector(store), (users, userId) => {
    //console.log(userId);
    return Users.AssignPlaces(users.asArray.filter(x =>
      x.id !== 1
      && x.totalPoints > 0
      && x.firstName !== 'Addie'
      && x.firstName !== 'Angela'
      && (x.id !== 36 || userId === 36 || userId === 1)
    ));
  });
}

export function usersLoadedSelector(store: Store<any>): Observable<boolean> {
  return usersSelector(store).pipe(
    map(x => x.usersLoaded),
    distinctUntilChanged()
  );
}

export function contestantsRemainingSelector(store: Store<any>): Observable<number> {
  return contestantsArraySelector(store).pipe(
    map(x => x.filter(y => !y.eliminated).length),
    distinctUntilChanged()
  );
}

export function activeUserTotalPointsSelector(store: Store<any>): Observable<number> {
  return activeUserContestantRankingsSelector(store).pipe(
    map(x => x.reduce((acc, y) => acc + y.points, 0))
  );
}

export function currentUserHasRankingsSelector(store: Store<any>): Observable<boolean> {
  return combineLatest(allUsersSelector(store), currentUserIdSelector(store), currentUserRankingsSelector(store),
    (users, userId, rankings) => users.findIndex(x => x.id === userId) !== -1 || rankings.length > 0).pipe(
      distinctUntilChanged()
    );
}
