namespace CS01
{
    public delegate void EventInput(string input);
    class UserInput
    {
        public EventInput ? EventInput { get; set; }
        public void GetInput()
        {
            do
            {
                Console.WriteLine("Enter something:");
                string input = Console.ReadLine();
                EventInput?.Invoke(input);

            } while (true);

        }
    }

}
