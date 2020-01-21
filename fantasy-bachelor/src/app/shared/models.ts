import { Metadata, build, Validators, BaseEntity, Collection, CurrentUser as BaseCurrentUser, OrderedItem, Permutation, TypeConstructor, toArray, compareNumbers, toInt } from '@caiu/library';

export { BaseEntity } from '@caiu/library';

export class User {
  id = 0;
  email = '';
  firstName = '';
  lastName = '';
  order = 0;
  paid = false;
  pickToWinName = 'N/A';
  place = '';
  totalPoints = 0;
}

export class Users extends Collection<User> {

  static AssignPlaces(data: User[]): User[] {
    const groupedByPointTotal = data.reduce((acc, x) => Object.assign({}, acc, { [x.totalPoints]: [...toArray(acc[x.totalPoints]), x] }), {});
    return Object.keys(groupedByPointTotal).sort((a, b) => compareNumbers(toInt(a), toInt(b))).reverse()
      .map((pts, i) => groupedByPointTotal[pts].map(y => build(User, y, {
        order: i + 1,
        place: groupedByPointTotal[pts].length > 1 ? `T${i + 1}` : `${i + 1}`
      }))).reduce((acc, x) => [...acc, ...x], []);
  }

  usersLoaded = false;

  constructor() {
    super(User);
  }

  update(data: User | User[]): Users {
    return build(Users, super.update(data), { usersLoaded: true });
  }
}

export class CurrentUser extends BaseCurrentUser {
  static Build(data: any): CurrentUser {
    return build(CurrentUser, BaseCurrentUser.Build(data));
  }

  get metadata(): Metadata {
    return build(Metadata, {
      ignore: ['id', 'expiresInDate', 'isAdmin', 'password', 'passwordResetCode', 'role', 'token']
    });
  }
}

export class Login {
  email = '';
  password = '';

  get metadata(): Metadata {
    return build(Metadata, {
      email: {
        validators: [Validators.required, Validators.email]
      }
    });
  }
}

export class Ordering<T> {
  private _history: Permutation<T>[] = [];

  constructor(private _items: T[], public ctor: TypeConstructor<T>, public orderKey = 'order', public idKey = 'contestantSeasonId') { }

  get count(): number {
    return this.items.length;
  }

  get history(): Permutation<T>[] {
    return this._history;
  }

  get instance(): T {
    return new this.ctor();
  }

  get items(): T[] {
    return this._items.sort((a, b) => this.getItemOrder(a) - this.getItemOrder(b));
  }

  get maxIndex(): number {
    return this.count === 0 ? 0 : Math.max(...this.order.map(x => x.order));
  }

  get order(): OrderedItem<T>[] {
    return this.permutation.ranks;
  }

  get permutation(): Permutation<T> {
    return new Permutation<T>(
      this.items.map(
        item =>
          ({
            id: this.getItemId(item),
            order: this.getItemOrder(item)
          } as OrderedItem<T>)
      )
    );
  }

  get nextPosition(): number {
    return this.maxIndex + 1;
  }

  addItem(item: T): T[] {
    return this.addItemAtPosition(item, this.nextPosition);
  }

  addItemAtPosition(item: T, pos: number): T[] {
    const newItemId = this.getItemId(item);
    return [...this.items, build(this.ctor, item, { order: pos })].map(x => {
      const order = this.getItemOrder(x);
      const id = this.getItemId(x);
      return order <= pos || id === newItemId ? x : build(this.ctor, x, { order: order + 1 });
    });
  }

  archive(items?: T[]) {
    const permutation = items ? this.getPermutation(items) : this.permutation;
    this._history = [...this._history, permutation];
  }

  getItemId(item: T): any {
    return item[this.idKey];
  }

  getItemOrder(item: T): number {
    return item[this.orderKey];
  }

  getPermutation(items: T[]): Permutation<T> {
    return new Permutation(
      items.map(
        item =>
          ({
            id: this.getItemId(item),
            order: this.getItemOrder(item)
          } as OrderedItem<T>)
      )
    );
  }

  move(item: T, to: number): T[] {
    const from = this.getItemOrder(item);
    const itemId = this.getItemId(item);
    if (to === from) {
      return [...this.items];
    } else if (to < from) {
      return this.items.map(x => {
        const order = this.getItemOrder(x);
        const id = this.getItemId(x);
        return id === itemId ? build(this.ctor, x, { order: to }) : order < to || order > from ? x : build(this.ctor, x, { order: order + 1 });
      });
    } else {
      // to > from
      return this.items.map(x => {
        const order = this.getItemOrder(x);
        const id = this.getItemId(x);
        return id === itemId ? build(this.ctor, x, { order: to }) : order < from || order > to ? x : build(this.ctor, x, { order: order - 1 });
      });
    }
  }

  moveDown(item: T): T[] {
    return this.move(item, this.getItemOrder(item) + 1);
  }

  moveUp(item: T): T[] {
    return this.move(item, this.getItemOrder(item) - 1);
  }

  removeItem(item: T): T[] {
    return this.removeItemAtPosition(this.getItemOrder(item));
  }

  removeItemAtPosition(pos: number): T[] {
    return this.items
      .filter(item => this.getItemOrder(item) !== pos)
      .map(x => {
        const order = this.getItemOrder(x);
        return order < pos ? x : build(this.ctor, x, { order: order - 1 });
      });
  }

  updateItems(items: T[]): void {
    this.archive();
    this._items = items;
  }
}

export class Contestant {
  id = 0;
  age = 0;
  bio = '';
  eliminated = false;
  finish = 0;
  funFacts: string[] = [];
  hometown = '';
  profession = '';
  name = '';
  paid = false;
  src = '';
  userNotes = '';
  userPoints = 0;
  userRank = 0;
  userRankingId = 0;
}

export class Contestants extends Collection<Contestant> {
  constructor() {
    super(Contestant);
    this.items = {
      1: build(Contestant, {
        id: 1,
        src: 'assets/alayah.jpg',
        age: 24,
        bio: `Alayah may be best known as Miss Texas 2019, but this pageant queen has way more going on than just a beautiful smile. Before taking the crown in 2019, Alayah had entered and competed in the Miss Texas pageant three times; fourth time is the charm for this queen! When she's not traveling the state and making appearances as Miss Texas, Alayah enjoys hanging out with her gals on the San Antonio River Walk, drinking wine and giving back to her community. She is looking for a man who has strong goals for the future and won't hold her back when she wants to pursue passions of her own. Alayah is also ready for a family and hoping that Peter is on the same page. However, will this pageant girl be on good terms with the other ladies or will familiar faces from her past resurface?`,
        hometown: 'San Antonio, TX',
        profession: 'Orthodontist Assistant',
        name: 'Alayah',
        funFacts: [
          `Alayah studied English in college and in her spare time, she loves to write poetry.`,
          `Alayah's favorite social media platform is Reddit.`,
          `Alayah's spirit animal is the Texas Longhorn.`
        ],
        eliminated: true,
        finish: 16
      }),
      2: build(Contestant, {
        id: 2,
        src: 'assets/alexa.jpg',
        age: 27,
        bio: `Alexa may look like a total city girl, but she grew up hunting on a farm in Springfield, Illinois with her mom, dad and brother. Six years ago, Alexa made a big a change. She had just broken up with her high school sweetheart of seven years and was finally ready to live the city life. Since moving to Chicago, she got her esthetician license and opened her own waxing salon. Alexa is a total free spirit and has a lot of hippie in her. She's all about love and acceptance, but at the same time, this girl has opinions and isn't afraid to express them. She prides herself on being the type of person to call people out to their face rather than behind their back. The main thing Alexa wants in a husband is chemistry, both physical and emotional. She admits that sometimes she has trouble being vulnerable, but we have a feeling Peter will be able to break down those walls.`,
        hometown: 'Fort Worth, TX',
        profession: 'Cattle Rancher',
        name: 'Alexa',
        funFacts: [
          `Alexa loves amusement parks but hates roller coasters.`,
          `Alexa decided to move to Chicago during a game of heads or tails.`,
          `When Alexa isn't hitting the dance floors at local clubs, she's at home prepping for her next book club meeting.`
        ],
        eliminated: true,
        finish: 16
      }),
      3: build(Contestant, {
        id: 3,
        src: 'assets/avonlea.jpg',
        age: 27,
        bio: `Avonlea is looking for a gentleman who knows how to take care of a Texas woman. She may be a city-slicker now, but she lived on a ranch until she was 13, and up until that point in her life, she assumed everyone had cattle in their homes. With her degree in ranch management, this Texas beauty has quite a diverse lifestyle. When Avonlea's not working hard in the family cattle ranching business, she's strutting her stuff on the runway for local Texas designers. "There are days when I'm baling hay in the morning and going and doing a runway show at night." You could definitely say Avonlea lives the best of both worlds. Avonlea's ideal husband knows what he wants and goes for it! She wants someone who values family above all and believes in romantic signs from above. Speaking of signs, Avonlea's parents first met when her mom was a flight attendant. Sound familiar?`,
        hometown: 'Chicago, IL',
        profession: 'Esthetician',
        name: 'Avonlea',
        funFacts: [
          `Avonlea is a certified scuba diver and has traveled to almost all 50 states in an RV.`,
          `Every time Avonlea milks one of her cows, she thanks it for its hard work.`,
          `Avonlea enjoys playing the guitar and snuggling up by the fire to listen to a good audiobook.`
        ],
        eliminated: true,
        finish: 23
      }),
      4: build(Contestant, {
        id: 4,
        src: 'assets/courtney.jpg',
        age: 26,
        bio: `Courtney is a Florida girl through and through. She enjoys going boating with friends, tanning at the beach and going out for drinks. She has been in two serious relationships and is done wasting her time with boys. Courtney's ready for a man. She is looking forward to settling down with the right guy: "I am genuinely looking to get married because I believe everyone has a soul mate out there in the world and I, unfortunately, have yet to find mine." Her ideal man should be tall and athletic, have a bright smile and be able to make her laugh. Will this hopeless romantic be able to find her soul mate in Peter, or will she fall flat on finding her Forever?`,
        hometown: 'Venice, FL',
        profession: 'Cosmetologist',
        name: 'Courtney',
        funFacts: [
          `Courtney is extremely claustrophobic.`,
          `Nothing makes Courtney happier than drinking a nice glass of wine while taking in a gorgeous view.`,
          `Courtney's biggest turn on is a man in cowboy boots.`
        ],
        eliminated: true,
        finish: 20
      }),
      5: build(Contestant, {
        id: 5,
        src: 'assets/deandra.jpg',
        age: 23,
        bio: `Deandra is an independent, intelligent woman who comes from a diverse background and isn't afraid to be herself. She was born in Texas, but grew up in Maine and spent a lot of time in Nigeria where her father was born. She's now moved back to Texas and loves to spend her free time bar hopping and trying out new restaurants. One thing Deandra has going for her is that since she grew up with 10 siblings, she knows how to stand out in a crowded room. Her favorite feeling in the world is being the center of attention and, according to her mom, she thrives in the spotlight. Deandra has been in one serious relationship in her life and is ready to find her forever. She's looking for someone to be as loyal to her as she would be to them and wants a man who will kill a spider for her as she runs away screaming. Deandra also says that any man she commits to must be willing to spend the holidays with her family, as that time of year is non-negotiable. They go all out and will have an extra seat at the table this year in case Deandra comes home hand in hand with Peter!`,
        hometown: 'Plano, TX',
        profession: 'Home Care Coordinator',
        name: 'Deandra',
        funFacts: [
          `Deandra considers herself to be a farmer's market aficionado.`,
          `Deandra hates EDM.`,
          `Deandra still cries when she gets her blood drawn.`
        ]
      }),
      6: build(Contestant, {
        id: 6,
        src: 'assets/eunice.jpg',
        age: 23,
        bio: `Eunice is a reformed party girl who is ready to get serious about settling down. She's left her sorority party days behind her and now spends her days flying the friendly skies as a flight attendant. Eunice is on the lookout for a quality man with a good heart. In the past, Eunice says she has never dated a guy who put her first and has made poor decisions when it comes to relationships. Her family has never met any of her boyfriends because they wouldn't have approved of the bad boys she dated, but she looks at that as a positive thing. She's coming into this experience with a clean slate, and we have a feeling if Eunice gets the chance to bring Peter home, it will be smooth skies from here on out.`,
        hometown: 'Chicago, IL',
        profession: 'Flight Attendant',
        name: 'Eunice',
        funFacts: [
          `Eunice's favorite holiday is Christmas because she loves Christmas music.`,
          `Eunice's favorite country to visit is Greece, and she can knock back ouzo like it's water.`,
          `Eunice's signature dance move is the ponytail helicopter.`
        ],
        eliminated: true,
        finish: 23
      }),
      7: build(Contestant, {
        id: 7,
        src: 'assets/hannah-ann.jpg',
        age: 23,
        bio: `Hannah Ann was born in Knoxville, Tennessee, and grew up there with her younger sister and younger brother. Her parents are not only her role models, they are also her landlords, as she still lives at home. Hannah Ann is a talented painter and loves to dabble in interior decorating when she's not slaying it in front of the camera as a model. She travels the world for work and would love to find man to join her on the adventure. She has a cute southern twang which, we know, Peter is a sucker for. Hannah Ann describes her last relationship as all chemistry but little friendship. Now, Hannah Ann is ready to find a man who she can be best friends with while keeping the steamy romance alive. We have a feeling this won't be a problem for Pilot Pete.`,
        hometown: 'Knoxville, TN',
        profession: 'Model',
        name: 'Hannah Ann',
        funFacts: [
          `Hannah Ann could watch home improvement shows all day and never get bored.`,
          `When Hannah Ann is nervous, she becomes very talkative.`,
          `Hannah Ann's home is decorated with artwork that she painted.`
        ]
      }),
      8: build(Contestant, {
        id: 8,
        src: 'assets/jade.jpg',
        age: 26,
        bio: `Jade is here for a fresh start! She grew up in the Mormon culture where she says there was a lot of pressure to get married and, unfortunately for Jade, that's what she did. At 22 years of age, she knew right away that she and her ex were not compatible for the long haul. Now that Jade's divorce is finalized, she has a new outlook on love and knows exactly what she is looking for. She spends her time working as a flight attendant and is currently working towards getting her private pilot's license. When's she's not on the job, she loves to go line dancing and considers herself to be a two-step queen! Are her and Peter too similar? Or will these two hit it off immediately and line dance straight into each other's hearts?`,
        hometown: 'Mesa, AZ',
        profession: 'Flight Attendant',
        name: 'Jade',
        funFacts: [
          `Jade claims that she hosts the best game night in town.`,
          `Even though she is a flight attendant, Jade is VERY afraid of heights.`,
          `If Jade has to assign an aesthetic to her life, it would be "organized chaos."`
        ],
        eliminated: true,
        finish: 23
      }),
      9: build(Contestant, {
        id: 9,
        src: 'assets/jasmine.jpg',
        age: 25,
        bio: `Jasmine is not here to mess around. She has been in one serious relationship that lasted for three years, but when her ex suddenly decided that he did not want to have kids, Jasmine sent him packing because that's a deal breaker for her. She enjoys traveling, attending her book club meetings, cooking, rock climbing and volunteering at her church every Sunday. She would like to travel the world before she starts a family and specifically would like to go back to Vietnam where her family is from. Jasmine speaks Vietnamese fluently and loves the Vietnamese traditions her family has incorporated into their lives. Jasmine is looking for loyalty, integrity and honesty in her next relationship. Additionally, she will consider proposing herself if she finds a man who can get her Chick-Fil-A on a Sunday. She is excited for the chance to fall in love again and can't wait for her Bachelor journey to begin!`,
        hometown: 'Houston, TX',
        profession: 'Client Relations Manager',
        name: 'Jasmine',
        funFacts: [
          `Jasmine's biggest turn off is a guy who sits on the couch all day and plays video games.`,
          `Jasmine will know that she's met the man of her dreams when he can help her build a table.`,
          `Jasmine's best friend is her golden retriever, Gnarles Barkley.`
        ],
        eliminated: true,
        finish: 16
      }),
      10: build(Contestant, {
        id: 10,
        src: 'assets/jenna.jpg',
        age: 22,
        bio: `Jenna is a fun, down to earth, Midwestern girl. She's looking for a man to grow old with who can keep life exciting. She wants someone who is kind and nurturing, but also spontaneous and adventurous. After a life-changing trip to Africa for a medical mission, Jenna realized that she needed to start doing activities to make herself happy and not be such a pushover. When she's not working her tail off to get her nursing degree, she loves to go take the Chicago nightlife by storm where she can often be found leading her trivia team to victory and shooting darts. Jenna's biggest fear in this whole process is being sent home before getting a chance to show Peter all that she has to offer, but we don't think she has any reason to be worried.`,
        hometown: 'New Lenox, IL',
        profession: 'Nursing Student',
        name: 'Jenna',
        funFacts: [
          `Jenna is a passionate foodie who would do anything to eat pasta with Chrissy Teigen one day.`,
          `Jenna has a pet goldfish named George, and she says that George gives great advice.`,
          `When Jenna is not bowling strikes at the local alley, she's at home knitting.`
        ],
        eliminated: true,
        finish: 23
      }),
      11: build(Contestant, {
        id: 11,
        src: 'assets/katrina.jpg',
        age: 28,
        bio: `Marriage is a big topic at the family dinner table. Katrina's parents are high school sweethearts that have been together for 40 years. Her younger brother is marrying his high school sweetheart next April, and her younger sister will probably get engaged soon to her serious boyfriend. Katrina's the last one left and, according to her mom, Katrina needs to settle down soon because "her biological clock is ticking." Katrina describes herself as the life of the party and prides herself on her ability to make everyone feel welcomed. Katrina loves to take over the dance floor and hopes to one day be a college dance coach. The most serious relationship Katrina currently has is with her hairless cat, Jasmine. Jasmine (named after her favorite Disney princess, of course) and Katrina literally do everything together, from birthday parties to shopping to watching TV on the couch. They are definitely a packaged duo, but there's room for one more on their magic carpet ride.`,
        hometown: 'Chicago, IL',
        profession: 'Pro Sports Dancer',
        name: 'Katrina',
        funFacts: [
          `Last Halloween, Katrina dressed up as her hairless cat, Jasmine, and Jasmine dressed up as her.`,
          `On the weekends, Katrina loves to stay up late and eat junk food.`,
          `Katrina's biggest pet peeve is not being in control.`
        ],
        eliminated: true,
        finish: 23
      }),
      12: build(Contestant, {
        id: 12,
        src: 'assets/kelley.jpg',
        age: 28,
        bio: `Kelley is a modern woman who doesn't need a man to take care of her. She has incredibly high standards and is looking for a man to push her forward instead of holding her back. Her most recent relationship was an international long-distance affair where she was traveling to Jordan once or twice a month, but finally got to the point where she couldn't see herself moving to the Middle East. Now that Kelley is single, she is focused on her career as an attorney. Kelley comes from generations of lawyers and currently works in her dad's law firm. It's going to take a lot more than a handsome face and solid resume though to impress Kelley because this lawyer won't settle for anything less than she deserves. No objections here!`,
        hometown: 'Chicago, IL',
        profession: 'Attorney',
        name: 'Kelley',
        funFacts: [
          `Kelley is allergic to gluten, dairy and black tea.`,
          `Nothing makes Kelley angrier than when people don't listen to her.`,
          `Kelley loves to travel and has been to 26 countries.`
        ]
      }),
      13: build(Contestant, {
        id: 13,
        src: 'assets/kelsey.jpg',
        age: 28,
        bio: `Kelsey was born and raised in Iowa with her fraternal twin sister and younger sister. She enjoys exercising, cooking, traveling and competed at Miss USA after being crowned Miss Iowa in 2017. Coming from the pageant world, Kelsey is an old pro at competing with other women, but don't get it twisted, she's not looking for drama. Kelsey has had her share of relationship issues in the past, but thanks to frequent Pilates classes, she's in peak physical and spiritual form! She's hoping to find a partner to travel the world, experience new cultures and enjoy a good glass of red wine with. At 28, she has presumably lived more life than many of the other girls and knows what she wants: Peter Weber.`,
        hometown: 'Des Moines, IA',
        profession: 'Professional Clothier',
        name: 'Kelsey',
        funFacts: [
          `Kelsey says she is like an onion; she has many layers.`,
          `If you want to give Kelsey a gift, don't get her flowers. Get her chocolate!`,
          `Kelsey described her personality as feisty and stubborn.`
        ]
      }),
      14: build(Contestant, {
        id: 14,
        src: 'assets/kiarra.jpg',
        age: 23,
        bio: `Kiarra is a social butterfly that is ready to spread her wings! While she's very close to her mother and will definitely be looking for her approval the next time she brings home a man, Kiarra says she is ready to venture on her own and start her own family. She's been in two serious relationships, but both ended because of trust issues. She hates sports but enjoys shopping, fashion, style and anything involving social media. She also LOVES talking and says her greatest skill is that she can literally talk to a brick wall about anything and everything. Kiarra says her ideal mate is someone who makes her laugh but can also be serious. She's looking for "someone who is willing to find my car keys when I lose them once a week." Hopefully, the Bachelor will show up with his metal detector.`,
        hometown: 'Kennesaw, GA',
        profession: 'Nanny',
        name: 'Kiarra',
        funFacts: [
          `Kiarra's biggest fear is being trapped on the top of a roller coaster.`,
          `Kiarra is extremely turned off by men who grind their teeth.`,
          `Kiarra says she will pick napping over almost any other activity.`
        ]
      }),
      15: build(Contestant, {
        id: 15,
        src: 'assets/kylie.jpg',
        age: 26,
        bio: `Kylie is looking for that rom-com kind of love! She grew up in Northern California Wine Country, but recently relocated to Santa Monica to be close to the beach. Though she has left home, Kylie won't commit to a man until her family approves. That may be a good thing because Kylie has not had the best luck in the dating world. Her last and only relationship ended three years ago after her long-term boyfriend turned out to be a big cheater. She's been single ever since and says that the last time a guy tried to kiss her, she turned away and blamed it on not wanting to ruin her make up. It is very important that her family approves whomever she brings home next, and apparently, her mom really hopes it's Peter! Kylie is a planner, and in five years' time, she is hoping to be already married with a child (or one on the way) and living in a home in southern California. Westlake Village is basically Los Angeles, so could this all be destiny?`,
        hometown: 'Santa Monica, CA',
        profession: 'Entertainment Sales Associate',
        name: 'Kylie',
        funFacts: [
          `Flakey and pessimistic people make Kylie mad.`,
          `Kylie's dream vacation would be to go on safari in Africa.`,
          `Kylie grew up playing softball and is a batting cage queen.`
        ],
        eliminated: true,
        finish: 23
      }),
      16: build(Contestant, {
        id: 16,
        src: 'assets/lauren.jpg',
        age: 26,
        bio: `Lauren is a boss woman looking to add balance to her life. She works as a marketing executive for a beauty company and also manages her own fashion blog. Now that she feels her career is in a good spot, she seems to have everything in place except for a man, but not just any man will do. She says her father and grandfather have been great examples of what husbands should be to a woman, and Lauren expects nothing less of her partner. Lauren is hoping to find a man who will open the car door for her and will hold her hand on the way to Sunday church. She also wants a man who will support her career ambitions and not hold her back. While competitive dance has been her favorite sport, she's always open to a good game of tonsil hockey. Suit up, Peter!`,
        hometown: 'Glendale, CA',
        profession: 'Marketing Executive',
        name: 'Lauren',
        funFacts: [
          `Lauren says she has exit interviews with all of her exes to figure out what went wrong.`,
          `Lauren has traveled all over the world, but has yet to go the one place on her bucket list: Texas.`,
          `During Lauren's one season as a Laker Girl, she was so inspired by Kobe's passion for things outside of basketball that she left the team to pursue her other dreams.`
        ],
        eliminated: true,
        finish: 20
      }),
      17: build(Contestant, {
        id: 17,
        src: 'assets/lexi.jpg',
        age: 26,
        bio: `Lexi is a smart, independent and fun woman who is ready to find the future father of her children. She grew up in Jacksonville, Florida and is one of six siblings. Lexi went to Florida State University and left college with a very serious boyfriend, but after moving to New York City, he ended things so they could both pursue their own careers and passions. Lexi stayed in New York City and has since been doing well as a marketing coordinator for a real estate company. She has been on a number of bad and mediocre dates around New York and can't seem to find the right guy. Lexi believes that dating as a redhead is hard, but she's hopeful that Peter will like to spice things up the way only a ginger girl can!`,
        hometown: 'New York, NY',
        profession: 'Marketing Coordinator',
        name: 'Lexi',
        funFacts: [
          `Lexi would rather be buried alive than be trapped in a room filled with frogs.`,
          `Lexi loves her home in Florida, but has too much sass for the suburb life.`,
          `Nothing turns Lexi off more than people who are desperate.`
        ]
      }),
      18: build(Contestant, {
        id: 18,
        src: 'assets/madison.jpg',
        age: 23,
        bio: `She shoots! SHE SCORES! That is something Madison is used to hearing. This Alabama cutie not only helped lead her high school basketball team to four state championships, she was also once named state MVP thanks to her unstoppable jump shot. She credits a lot of her success to her dad who coached her and always encouraged her to dream big. While basketball has always been her first love, she knows that it can't give her everything she needs, and at 23, Madison is more than ready to find her forever. She's looking for a man who will prioritize faith and family before everything else. She is hoping to find someone who shares the same religious values that she and her family have. He also MUST want children and know how to have fun. Her dream is to travel the world and spread love through missionary work. Madison has high expectations, but she's hopeful that one day, she'll board a plane and sitting next to her will be the man of her dreams. Maybe she should check the cockpit instead!`,
        hometown: 'Auburn, AL',
        profession: 'Foster Parent Recruiter',
        name: 'Madison',
        funFacts: [
          `If Madison was stranded on an island and could only bring one book, it would be The Bible.`,
          `Madison loves working with foster kids and wants to open an orphanage one day.`,
          `Madison would rather rock a cool pair of Jordans than any heel.`
        ]
      }),
      19: build(Contestant, {
        id: 19,
        src: 'assets/maurissa.jpg',
        age: 23,
        bio: `Maurissa is a bold beauty that is ready to find her husband. In high school, Maurissa competed in the Miss Teen USA pageants and was crowned Miss Teen Montana, but she says it was one of the worst times in her life. She was average size for a teenage girl, but the pageant world made her feel insecure about her weight, which lead her to struggle with body image issues. During this time, Maurissa was in a five-year relationship with her high school sweetheart. He was always someone who encouraged Maurissa to feel beautiful, and she thought she was going to marry him. Unfortunately, the two of them had conflicting ideas for the future, and they broke up when Maurissa realized that he did not want to get married as soon as she did. Soon after the breakup, Maurissa moved to Atlanta and stepped up her fitness routine. As of now, Maurissa has lost 80 pounds and wants to keep going! For the last four years, Maurissa has dated around but hasn't found anyone as serious about marriage as she is. She's looking for a man who is fun spirited, but also ready for a commitment, and if she hits it off with Peter right away, she plans on going hard!`,
        hometown: 'Atlanta, GA',
        profession: 'Patient Care Coordinator',
        name: 'Maurissa',
        funFacts: [
          `Maurissa recently left the United States for the first time and went on a girl's trip to the Caribbean.`,
          `When Maurissa is feeling confident, she breaks into song.`,
          `Maurissa prefers to surround herself with people who have a more mature outlook on life. All of her best friends are at least 10 years older than her.`
        ],
        eliminated: true,
        finish: 23
      }),
      20: build(Contestant, {
        id: 20,
        src: 'assets/megan.jpg',
        age: 26,
        bio: `Just like her mother and grandmother before her, Megan became a flight attendant with the goal of seeing the world. Her parents split up when she was 18, but Megan still considers herself the definition of a hopeless romantic. She is actually grateful that things worked out the way they did because she has gotten to see her mom fall in love again with her amazing stepdad. She says she has been in a few serious relationships, but only during one, year-long affair, would she say that she was ever truly in love. When she's not flying the friendly skies, she loves hiking, skiing and hitting the dog park with her pup, Bear. She would love to find a man who loves his career as much as she does and who can join her for spontaneous trips back to Portland to spend time with her family. Megan is incredibly hopeful that true love is just around the corner and is hoping that she finds it when she gets out of the limo!`,
        hometown: 'San Francisco, CA',
        profession: 'Flight Attendant',
        name: 'Megan',
        funFacts: [
          `Megan's mother is her best friend. They talk every day.`,
          `Megan is a facemask enthusiast.`,
          `One day, Megan hopes to travel to Zion National Park.`
        ],
        eliminated: true,
        finish: 23
      }),
      21: build(Contestant, {
        id: 21,
        src: 'assets/mykenna.jpg',
        age: 22,
        bio: `Mykenna may love to curate chic outfits, but she's way more than a pretty girl in a photo! She is here to find love and isn't going to settle for anyone who won't impress her family. Above all else, Mykenna loves her family. She is super close to her parents and is constantly inspired by her grandparent's love, which makes sense, as they were together for 61 years and her grandpa proposed to her grandma on their first date. Mykenna has been in one relationship, but she ended it when he became too controlling. She's looking for someone who will surprise her with romantic adventures, but will also be ok with it when she wants to go out drinking and dancing with her friends. Mykenna says, "I want the good and the bad. I want to laugh, be goofy and be spontaneous with my person, but I also want a relationship where we challenge each other. I don't want an easy love!" Well, this journey definitely will not be easy, but it will be worth it!`,
        hometown: 'Langley, BC, Canada',
        profession: 'Fashion Blogger',
        name: 'Mykenna',
        funFacts: [
          `Mykenna is obsessed with ABC's Grey's Anatomy.`,
          `Mykenna's dream job is to start her own charity.`,
          `Mykenna loves to go to car shows with her dad.`
        ]
      }),
      22: build(Contestant, {
        id: 22,
        src: 'assets/natasha.jpg',
        age: 31,
        bio: `Natasha is here to prove that mysterious is sexy! She makes her presence known whenever she enters a room. She plans parties for a living, but loves her quiet time where she can meditate and focus on her spirituality. A normal Saturday night is either a big dinner with friends that she organized, or she's home watching a movie or reading – it's one extreme or the other. Natasha has been in two serious relationships, but neither one was ever close to marriage. She wants someone who is kind, smart and laid back, but who also knows how to have a good time. She prides herself on being someone you can count on, and would always be there for her man. She says she has never been the type to approach a guy first, but since that hasn't been working, she's looking to change things up here and take the bull by the horns! Watch out, Peter, Natasha is coming in hot!`,
        hometown: 'New York, NY',
        profession: 'Event Planner',
        name: 'Natasha',
        funFacts: [
          `If Natasha could pioneer her own fitness movement, it would be disco yoga.`,
          `Natasha loves her legs and her back where she has a cross and dagger tattoo.`,
          `Natasha is afraid of rats, mice, spiders and anything that crawls.`
        ]
      }),
      23: build(Contestant, {
        id: 23,
        src: 'assets/payton.jpg',
        age: 23,
        bio: `Payton is the type of woman who goes into a bar alone and leaves with 100 new best friends. She grew up in Ohio with her four siblings, and thanks to some serious Facebooking, she recently discovered that she has a fifth! After a stranger messaged her, she found out she has a long-lost sister. Payton had a serious boyfriend in college and says that they were in love. They dated for three years, but by her junior year, he started getting jealous of her social life and tried to control her. She lost herself in trying to please him and ended that relationship so she could spend the rest of her time in college having fun. Payton describes herself as outgoing and very fun. She is not very athletic, but loves to be outdoors. Her favorite way to socialize is over a good glass of wine, and she is coming into this with two glasses. Hopefully, Peter is thirsty!`,
        hometown: 'Wellesley, MA',
        profession: 'Business Development Rep',
        name: 'Payton',
        funFacts: [
          `Payton loves to be the life of the party and her biggest fear is missing out.`,
          `Payton is not afraid of talking to strangers. In fact, she enjoys it!`,
          `Payton has a cute bulldog named Louise.`
        ],
        eliminated: true,
        finish: 20
      }),
      24: build(Contestant, {
        id: 24,
        src: 'assets/sarah.jpg',
        age: 24,
        bio: `Sarah may be a Southern belle, but she dreams of a life outside Tennessee. After coming close to an engagement with her last boyfriend, Sarah is single and ready to grab life by the horns. She enjoys being outdoors, paddle boarding, reading, listening to podcasts and binge watching a good series on a rainy day. She loves to cook and find fun, healthy recipes to make throughout the week. Sarah is ready to find her partner in all adventures, and is looking for someone who appreciates her drive and has similar life passions. Good thing Peter loves to eat!`,
        hometown: 'Knoxville, TN',
        profession: 'Medical Radiographer',
        name: 'Sarah',
        funFacts: [
          `Sarah's favorite vacation spot is Key West, Florida.`,
          `Sarah loathes slugs.`,
          `Sarah loves listening to electronic music.`
        ],
        eliminated: true,
        finish: 16
      }),
      25: build(Contestant, {
        id: 25,
        src: 'assets/savannah.jpg',
        age: 27,
        bio: `Savannah is a Texas girl who is ready to expand her horizons past the Lone Star State. She was in an on-and-off relationship for six years, but he couldn't show love or be romantic with her, which was a big problem. Also, during one of the "off" times, he slept with one of her friends, which ended things for good. Now that she's ditched that zero, she's hoping to find her hero in Peter. This successful realtor loves being the center of attention and says that she has a bad habit of laughing at inappropriate moments. She enjoys roller skating and shopping at Revolve. Savannah has never really left her comfort zone in Texas, so she's hoping to fall in love with a pilot who can show her the world.`,
        hometown: 'Houston, TX',
        profession: 'Realtor',
        name: 'Savannah',
        funFacts: [
          `When Savannah wants to treat herself, she indulges in a Vampire Facial.`,
          `Savannah's favorite thing to do to pass time is sit on her back porch and feed the local turtles, which is why she often refers to herself as "The Turtle Princess."`,
          `Savannah used to have a cancer ribbon tattoo on her ribs, but removed it for the Houston Texans cheer tryouts.`
        ]
      }),
      26: build(Contestant, {
        id: 26,
        src: 'assets/shiann.jpg',
        age: 27,
        bio: `Shiann comes from Las Vegas and is putting all her bets on Peter! Shiann's hobbies include traveling to foreign countries and competitive horseback riding. She describes herself as a caring, loyal and understanding partner who when she loves, she loves hard. Falling in love has been difficult in the past for Shiann because every guy she's dated either ended up ghosting her, having a wife and kids, or liking her friends over her, but we have a feeling it's only happy times ahead for this high roller.`,
        hometown: 'Las Vegas, NV',
        profession: 'Administrative Assistant',
        name: 'Shiann',
        funFacts: [
          `According to Shiann, the best part of her body is her lower back.`,
          `Skydiving is at the top of Shiann's bucket list.`,
          `Shiann was a competitive horseback rider growing up.`
        ]
      }),
      27: build(Contestant, {
        id: 27,
        src: 'assets/sydney.jpg',
        age: 24,
        bio: `Sydney loves love! She has always been a relationship type of girl, but the end of her last relationship really crushed her. After being together for two years, she and her boyfriend were planning on moving in together, and while it was an up-and-down relationship, she really thought he was the one. Right when her lease was up and they had begun looking for places together, he told Sydney that she wasn't the one and ended the relationship immediately. Sydney was devastated, but has spent these last few months rebuilding her broken heart and preparing to get back out there. She is looking to find that one person who wants to fully give his all to her and build their lives together. She loves to hike, dance and plan fantasy vacations for her and her future husband. She also loves to bake and says that her dream man will have a sweet tooth just like her. Sydney is fiery, fierce and not a force you want to mess with.`,
        hometown: 'Burmingham, AL',
        profession: 'Retail Marketing Manager',
        name: 'Sydney',
        funFacts: [
          `Sydney's favorite holiday is Valentine's Day.`,
          `ydney's ability to speak Spanish is so-so, but on salsa night, she rules the dance floor.`,
          `Sydney tries to jog at least once a day and then likes to reward herself with a cupcake she bakes herself. Sweet!`
        ]
      }),
      28: build(Contestant, {
        id: 28,
        src: 'assets/tammy.jpg',
        age: 24,
        bio: `Tammy is in the process of taking over the world and if a man can't keep up, then she isn't afraid to leave them in the dust. She comes from a hardworking family that immigrated over to Syracuse during the Vietnam War and credits her go-go-go attitude to her parents. After her parents split up, she helped raise her younger sisters and has been working ever since graduating high school. Speaking of high school, Tammy tried to join the boys wrestling team as a junior but was turned away! She responded by showing up to every practice and pushing forward on a Title IX complaint until they accepted her. Good thing they did, because once on the team, she went on to have a 7-1 record wrestling on the boys' varsity team. Tammy's busy work life hasn't given her too much time to date. She has been unable to find anyone in Syracuse who can keep up with her ambitious nature, and she finds it hard to date men her age because her drive tends to intimidate them. Tammy is coming into this experience to focus on finding true love and to see if Peter is the type of guy who can give her the work-life balance she needs. One problem though: Tammy hasn't told her mom yet that she's going to be on The Bachelor. Guess now is as good a time as any! Surprise, Mom!`,
        hometown: 'Syracuse, NY',
        profession: 'House Flipper',
        name: 'Tammy',
        funFacts: [
          `Tammy loves to travel so much that she has the vanity license plate "JETSETTR."`,
          `Tammy ended her last relationship by ghosting him.`,
          `Tammy considers herself a tomboy and doesn't relate well to the "blonde Barbie" types.`
        ]
      }),
      29: build(Contestant, {
        id: 29,
        src: 'assets/victoria-f.jpg',
        age: 25,
        bio: `Victoria has lived in Virginia Beach her entire life and is very tied into her local community.
        She works part time at a yoga studio, but her true passion is her career in medical sales where she works super hard.
        Victoria is looking for a guy that can make her laugh and melt her heart.
        She wants a man who can love her through the good, the bad and the ugly.
        She wants a man who can not only give her unconditional love, but can also give that love to her dog Buxton because they are a package deal.
        Victoria says that it's hard for her to know someone likes her unless they are expressing it to her verbally, so good thing Peter has a way with words!
        `,
        hometown: 'Virginia Beach, VA',
        profession: 'Medical Sales Rep',
        name: 'Victoria F.',
        funFacts: [
          `Victoria loves a man who is in touch with his feelings and isn't afraid to cry in public.`,
          `Victoria is a big fan of country music and will travel to see her favorite artists play a show.`,
          `The most important woman in Victoria's life is her dear grandmother.`
        ]
      }),
      30: build(Contestant, {
        id: 30,
        src: 'assets/victoria-p.jpg',
        age: 27,
        bio: `While Victoria grew up in a small town, there was nothing simple about her upbringing. Victoria lost her father at a young age and both her mother and sister struggled with drug addiction. Victoria grew up fast and, as of three years ago, her mother and sister are now both sober and have a stronger family bond than ever before. Victoria is on The Bachelor because she has never given herself a fair shot at finding love. She has been in one serious relationship that lasted for two years, but his infidelity led to them breaking up after she stumbled upon a video on her ex's phone which proved he had been cheating on her. Victoria is a natural care giver but is ready to find someone who can care for her as much as she will for him. This former Miss Louisiana pageant girl has been forced to grow up fast and learn the importance of finding a supportive life partner. She wants someone who will be a wonderful father to their kids and will be the rock she never had. She gives the best hugs and is excited to wrap her arms around Peter as soon as she meets him!`,
        hometown: 'Alexandria, LA',
        profession: 'Nurse',
        name: 'Victoria P.',
        funFacts: [
          `If Victoria could travel anywhere in the world, she would go to Italy.`,
          ` Victoria's biggest fears are murky waters she can't see her feet in, and chicken served on the bone.`,
          `Nothing upsets Victoria more than finding raisins in her cookies.`
        ]
      }),
    };
  }
}

export class Ranking {
  id = 0;
  contestantAge = 0;
  contestantEliminated = false;
  contestantHometown = '';
  contestantName = '';
  contestantProfession = '';
  contestantSeasonId = 0;
  contestantSrc = '';
  notes = '';
  order = 0;
  points = 0;
  rank = 0;
  userId = 0;

  get metadata(): Metadata {
    return build(Metadata, {
      ignore: ['id', 'contestantAge', 'contestantHometown', 'contestantName', 'contestantProfession', 'contestantSrc', 'order', 'points']
    });
  }

  // set order(value: number) {
  //   this.rank = value;
  // }

  // get order(): number {
  //   return this.rank;
  // }
}

export class Rankings extends Collection<Ranking> {

  static CalculatePoints(rank: number, finish: number): number {
    let pts = 0;
    if (finish < 23 && rank < 23) {
      pts += 1;
    }
    if (finish < 20 && rank < 20) {
      pts += 2;
    }
    if (finish < 16 && rank < 16) {
      pts += 3;
    }
    return pts;
  }

  constructor() {
    super(Ranking);
  }

  update(data: Ranking | Ranking[]): Rankings {
    return build(Rankings, super.update(data));
  }
}
