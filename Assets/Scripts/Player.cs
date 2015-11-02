namespace Assets.Scripts
{
    public class Player
    {
        private readonly Paddle _paddle;
        public Player(Paddle paddle)
        {
            _paddle = paddle;
        }

        public Paddle Paddle
        {
            get { return _paddle; }
        }
    }
}
