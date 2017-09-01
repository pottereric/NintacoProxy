namespace Nintaco
{
    class AccessPoint
    {

        public readonly AccessPointListener listener;
        public readonly int type;
        public readonly int minAddress;
        public readonly int maxAddress;
        public readonly int bank;

        public AccessPoint(AccessPointListener listener, int type, int minAddress)
            : this(listener, type, minAddress, -1, -1)
        {
        }

        public AccessPoint(AccessPointListener listener, int type,
            int minAddress, int maxAddress) : this(listener, type, minAddress,
                maxAddress, -1)
        {
        }

        public AccessPoint(AccessPointListener listener, int type, int minAddress,
            int maxAddress, int bank)
        {

            this.listener = listener;
            this.type = type;
            this.bank = bank;

            if (maxAddress < 0)
            {
                this.minAddress = this.maxAddress = minAddress;
            }
            else if (minAddress <= maxAddress)
            {
                this.minAddress = minAddress;
                this.maxAddress = maxAddress;
            }
            else
            {
                this.minAddress = maxAddress;
                this.maxAddress = minAddress;
            }
        }
    }
}
