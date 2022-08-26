using System;
using System.Collections.Generic;
using System.Linq;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 42);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 30);
            Challenge headWeight = new Challenge(
                "How many pounds does the human head weigh? (2, 4, 6, 8)", 8, 15);
            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 30);
            Challenge hitchHiker = new Challenge(
                @"How many books are in 'The Hitchhiker's Guide to the Galaxy' trilogy?", 4, 30);
            Challenge pirateLetter = new Challenge(
                @"What is a pirates' favorite letter?
    1) R
    2) O
    3) C
    4) K
",
                 3, 30);
            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20);

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            Robe newRobe = new Robe
            {
                Colors = new List<string>{"red", "white", "blue"},
                Length = 60
            };

            Hat newHat = new Hat
            {
                ShininessLevel = 8
            };

            Prize newPrize = new Prize("Congratz, you are so awesome!");

            // Make a new "Adventurer" object using the "Adventurer" class
            Console.WriteLine("Who goes there?");
            string userName = Console.ReadLine();
            Adventurer theAdventurer = new Adventurer(userName, newRobe, newHat);
            Console.WriteLine(theAdventurer.GetDescription());

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                headWeight,
                pirateLetter,
                hitchHiker
            };

            var rnd = new Random();
            var randomChallenges = challenges.OrderBy(item => rnd.Next());

            // Loop through all the challenges and subject the Adventurer to them
            void TheGame()
            {
                
                int counter = 1;
                foreach (Challenge challenge in randomChallenges)
                    if (counter <= 5)
                    {
                        challenge.RunChallenge(theAdventurer);
                        counter ++;
                    }
                    else
                    {
                        break;
                    }
                
                

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                newPrize.ShowPrize(theAdventurer);
                
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }

                Console.Write("Would you like to try again (y/n)?");
                string playAgain = Console.ReadLine();
                if (playAgain == "y")
                {
                    theAdventurer.Awesomeness = theAdventurer.Awesomeness + (theAdventurer.SuccessCounter * 10);
                    theAdventurer.SuccessCounter = 0;
                    TheGame();
                }
            }
            TheGame();
        }
    }
}