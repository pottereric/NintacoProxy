namespace Nintaco
{
    class ScanlinePoint
    {

        public readonly ScanlineListener listener;
        public readonly int scanline;

        public ScanlinePoint(ScanlineListener listener, int scanline)
        {
            this.listener = listener;
            this.scanline = scanline;
        }
    }
}
