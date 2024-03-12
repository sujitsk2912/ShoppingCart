namespace ShoppingCart_Application
{
    internal class RazorpayClient
    {
        private string key;
        private string secret;

        public RazorpayClient(string key, string secret)
        {
            this.key = key;
            this.secret = secret;
        }
    }
}