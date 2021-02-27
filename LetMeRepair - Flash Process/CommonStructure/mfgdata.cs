namespace CommonStructure
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct mfgData
    {
        public string modelNumber;
        public string sn;
        public string pn;
        public string cn;
        public string IMEI;
        public string MEID;
        public string BDA;
        public string SecBDA;
        public string MAC;
        public string SecMAC;
        public string ZigBeeAddress;
    }
}