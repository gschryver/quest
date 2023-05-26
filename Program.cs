using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {

            // Our adventurer is currently named "Jack". Studies show that "Jack" is probably not the application user's name. Update the code to prompt the user for their name and pass that name to the Adventurer constructor when creating the new Adventurer object.
            Console.Write("What is your name?: ");
            string Name = Console.ReadLine();

            var robe = new Robe();
            robe.Colors = new List <string> { "an elegant blue with silver moons embroidered into the velvet fabric" };
            robe.Length = 40;

            var hat = new Hat ();
            hat.ShininessLevel = 10;

            var prize = new Prize("An unimaginably large pile of super soft plushies!");


            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
                1) John
                2) Paul
                3) George
                4) Ringo
            ",
                4, 20
            );

            Challenge colorIsSky = new Challenge(
                 @"What color is the sky?
                1) Blue
                2) Pink
                3) Green
                4) Orange
            ",
                1, 20
            );
            Challenge defineWord = new Challenge(
                @"What does the word 'defenestrate' mean?
                1) To dodge something
                2) To throw someone out of a window
                3) To be in a state of confusion 
                4) To be in a state of bliss
                ",
                
                2, 50);
            Challenge bestFoodEver = new Challenge(
                @"What is the best food ever?
                1. Donuts
                2. Ice Cream
                3. Pizza
                4. Tacos
                5. All of the above
                
                ", 
                5, 50);
            
            Challenge multiply = new Challenge("What is 100 x 100?", 10000, 20);
            Challenge divide = new Challenge("What is 100 / 100?", 1, 20);


            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            // Make a new "Adventurer" object using the "Adventurer" class
            Adventurer theAdventurer = new Adventurer(Name, robe, hat);
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
                colorIsSky,
                defineWord,
                bestFoodEver,
                multiply,
                divide
            };

            // // Loop through all the challenges and subject the Adventurer to them
            // foreach (Challenge challenge in challenges)
            // {
            //     challenge.RunChallenge(theAdventurer);
            // }

            // Let's show 5 random challenges to the user each game
            static List<Challenge> RandomlyPickChallenges(List<Challenge> challenges) { 
                List<Challenge> randomChallenges = new List<Challenge>();
                Random random = new Random();
                while (randomChallenges.Count < 5) { // while the list has less than 5 challenges
                    int index = random.Next(challenges.Count); // pick a random index
                    Challenge challenge = challenges[index]; // get the challenge at that index (index = 0 to 9)
                    if (!randomChallenges.Contains(challenge)) { // if the challenge isn't already in the list
                        randomChallenges.Add(challenge); // add it to the list
                    }
                }
                return randomChallenges;
            }

            // Loop through 5 random challenges and subject the Adventurer to them
            foreach (Challenge challenge in RandomlyPickChallenges(challenges))
            {
                challenge.RunChallenge(theAdventurer);
            }

            // This code examines how Awesome the Adventurer is after completing the challenges
            // And praises or humiliates them accordingly
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
            
            // offer prize if player has awesome score over 0 
            prize.ShowPrize(theAdventurer, "You win:");
            // offer the player to play again

            Console.WriteLine("Would you like to play again? (Y/N)");
            string playAgain = Console.ReadLine().ToLower();
            if (playAgain == "y")
            {
                Main(args);
            }
            else
            {
                Console.WriteLine("Goodbye!");
            }
        }
    }
}