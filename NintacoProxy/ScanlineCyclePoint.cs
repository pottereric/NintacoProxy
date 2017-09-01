namespace Nintaco
{
    class ScanlineCyclePoint
    {

        public readonly ScanlineCycleListener listener;
        public readonly int scanline;
        public readonly int scanlineCycle;

        public ScanlineCyclePoint(ScanlineCycleListener listener, int scanline,
            int scanlineCycle)
        {
            this.listener = listener;
            this.scanline = scanline;
            this.scanlineCycle = scanlineCycle;
        }
    }
}
