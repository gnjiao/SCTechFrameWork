using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareInterFaces
{
    public class PGMethodDefine : ISZPG, IPGDeMura
    {
        public string IP { get; set; }

        public int Port { get; set; }
        private IntPtr Handle = new IntPtr();

        public PGMethodDefine(string ip, int port)
        {
            this.IP = ip;
            this.Port = port;
        }

        public int Exit()
        {
            int Res = 0;
            if (Handle != null && Handle != IntPtr.Zero)
            {
                SCPGCtrl.SCPGCommExit(Handle);
            }
            else
            {
                Res = 1;
            }
            return Res;
        }

        public int GetPowerInfo(int channelIndex, out float[][] voltageInfo, out float[][] currentInfo)
        {
            TagPGVCParam PGVCParam = new TagPGVCParam();
            voltageInfo = new float[PGVCParam.wData.Length][];
            currentInfo = new float[PGVCParam.wData.Length][];

            int Res = SCPGCtrl.SCPGCommReadVCParam(Handle, out PGVCParam);

            for (int i = 0; i < PGVCParam.wData.Length; i++)
            {
                voltageInfo[i][0] = PGVCParam.wData[i].wVCh1;
                voltageInfo[i][1] = PGVCParam.wData[i].wVCh2;
                voltageInfo[i][2] = PGVCParam.wData[i].wVCh3;
                voltageInfo[i][3] = PGVCParam.wData[i].wVCh4;
                voltageInfo[i][4] = PGVCParam.wData[i].wVCh5;
                voltageInfo[i][5] = PGVCParam.wData[i].wVCh6;
                voltageInfo[i][6] = PGVCParam.wData[i].wVCh7;
                voltageInfo[i][7] = PGVCParam.wData[i].wVCh8;
                currentInfo[i][0] = PGVCParam.wData[i].wCCh1;
                currentInfo[i][1] = PGVCParam.wData[i].wCCh2;
                currentInfo[i][2] = PGVCParam.wData[i].wCCh3;
                currentInfo[i][3] = PGVCParam.wData[i].wCCh4;
                currentInfo[i][4] = PGVCParam.wData[i].wCCh5;
                currentInfo[i][5] = PGVCParam.wData[i].wCCh6;
                currentInfo[i][6] = PGVCParam.wData[i].wCCh7;
                currentInfo[i][7] = PGVCParam.wData[i].wCCh8;
            }
            return Res;
        }

        public int GetResolution(ref int width, ref int height)
        {
            int Res = (int)SCPGCtrl.SCPGCommReadPixel(Handle, ref height, ref width);

            //ShowLog($"获取到屏幕的高：{height}，宽：{width}");

            return Res;
        }

        public bool Init()
        {
            bool Res = SCPGCtrl.SCPGCommInit(ref Handle, IP);
            if (Res && Handle != null)
            {
                //ShowLog($"PG IP为:{IP}初始化成功！",Color.Green,font);
            }
            else
            {
                //ShowLog($"PG IP为:{IP}初始化失败！",Color.Red,font);
            }
            return Res;
        }

        public int PowerOff()
        {
            int Res = (int)SCPGCtrl.SCPGCommPowerOff(Handle);

            return Res;
        }

        public int PowerOn()
        {
            int Res = (int)SCPGCtrl.SCPGCommPowerOn(Handle);

            return Res;
        }

        public int ReadICRegVal(int nAddre, int nLen, out byte[] regVal)
        {
            regVal = new byte[1024];
            int Res = SCPGCtrl.SCPGCommReadRegData(Handle, nAddre, out regVal, nLen);
            return Res;
        }

        public int ReadPGRegValue(int addr, int offset, int length, out int[] data)
        {
            data = new int[1024];
            int Res = SCPGCtrl.SCPGCommReadPGRegData(Handle, (short)addr, (short)offset, ref data, length);
            return Res;
        }

        public int SendFileByFtp(string fileName)
        {
            throw new NotImplementedException();
        }

        public int SetPattern(int index)
        {
            int Res = (int)SCPGCtrl.SCPGCommSetPattern(Handle, (byte)index);
            return Res;
        }

        public int SetRaster(byte r, byte g, byte b)
        {
            int Res = (int)SCPGCtrl.SCPGCommSetLevel(Handle, r, g, b);
            return Res;
        }

        public int ShowText(int posX, int posY, int FontSize, string Msg, Color color)
        {
            int Res = SCPGCtrl.SCPGCommShowText(Handle, posX, posY, FontSize, Msg, Msg.Length, (uint)ColorTranslator.ToWin32(color));
            return Res;
        }

        public int WriteICRegValue(byte[] regAddr, byte[] regVal)
        {
            throw new NotImplementedException();
        }

        public int WritePGRegValue(int addr, int offset, int length, int[] data)
        {
            int Res = SCPGCtrl.SCPGCommWritePGRegData(Handle, (short)addr, (short)offset, ref data, length);
            return Res;
        }

        public int DeMuraOTP(int flag)
        {
            throw new NotImplementedException();
        }

        public int DeMuraFunctionSwitch(bool bOn)
        {
            int Res = (int)SCPGCtrl.SCPGCommDemuraFunctionCtrl(Handle, bOn);
            return Res;
        }

        public int DeMuraFlashWrite()
        {
            throw new NotImplementedException();
        }

        public int ReadFlashID(out int flashID)
        {
            flashID = 0;
            int Res = (int)SCPGCtrl.SCPGCommReadFlashID(Handle, ref flashID);
            return Res;
        }

        public int DmrEffectCtrl(bool bOn)
        {
            int Res = (int)SCPGCtrl.SCPGCommDemuraFunctionCtrl(Handle, bOn);
            return Res;
        }

        public int DmrDataTransfer(string pDataPath)
        {
            int Res = (int)SCPGCtrl.SCPGCommDemuraDataTransfer(Handle, pDataPath);
            return Res;
        }

        public int ChangeModule(string Filename, int nLen)
        {
            int Res = (int)SCPGCtrl.SCPGCommChangeModule(Handle, Filename, nLen);
            return Res;
        }

        public int ReadCheckSum(ref ushort nCheckSum)
        {
            int Res = (int)SCPGCtrl.SCPGCommReadFlashChecksum(Handle, ref nCheckSum);
            return Res;
        }
    }
}