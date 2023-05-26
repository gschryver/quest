namespace Quest {
    public class Prize {
        private string _text;
        
        public Prize(string text) {
            _text = text;
        }
        
        public void ShowPrize(Adventurer adventurer, string message) {
    if (adventurer.Awesomeness > 0) {
        Console.WriteLine($"{message} {_text}");
    } else {
        Console.WriteLine("Haha, loser. You're not awesome enough to claim your prize. Better luck next time, dork!");
    }
}
    }
}