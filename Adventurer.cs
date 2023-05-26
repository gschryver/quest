namespace Quest
{
    // An instance of the Adventurer class is an object that will undergo some challenges
    public class Adventurer
    {
        // This is an "immutable" property. It only has a "get".
        // The only place the Name can be set is in the Adventurer constructor
        // Note: the constructor is defined below.
        public string Name { get; }

        // This is a mutable property it has a "get" and a "set"
        //  So it can be read and changed by any code in the application
        public int Awesomeness { get; set; }

        // add a new immutable property called ColorfulRobe. Type should be Robe
        public Robe ColorfulRobe { get; }
        public Hat ColorfulHat { get; }

        // add a new method called GetDescription. Should return a string that contains the adventurer's name and description of their robe
        public string GetDescription()
        {
            return $"{Name} is wearing a {ColorfulRobe.Length} inch long robe that is {string.Join(", ", ColorfulRobe.Colors)}. Their hat is {ColorfulHat.ShininessDescription}.";
        }

        // A constructor to make a new Adventurer object with a given name
        public Adventurer(string name, Robe colorfulRobe, Hat colorfulHat)
        {
            Name = name;
            Awesomeness = 50;
            ColorfulRobe = colorfulRobe;
            ColorfulHat = colorfulHat;
        }


        // This method returns a string that describes the Adventurer's status
        // Note one way to describe what this method does is:
        //   it transforms the Awesomeness integer into a status string
        public string GetAdventurerStatus()
        {
            string status = "okay";
            if (Awesomeness >= 75)
            {
                status = "great";
            }
            else if (Awesomeness < 25 && Awesomeness >= 10)
            {
                status = "not so good";
            }
            else if (Awesomeness < 10 && Awesomeness > 0)
            {
                status = "barely hanging on";
            }
            else if (Awesomeness <= 0)
            {
                status = "not gonna make it";
            }

            return $"Adventurer, {Name}, is {status}";
        }
    }
}