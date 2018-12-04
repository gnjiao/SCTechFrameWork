using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HardWareInterFaces;

namespace PGCtrlLib
{
    public class SZPGDeMuraCtrl : ISZPG, IPGDeMura
    {
        public string IP { get; set; }
        public int Port { get; set; }

        private IntPtr _handle;

        public IntPtr Handle
        {
            get { return _handle; }
        }

        private static readonly object lockobj = new object();

        public SZPGDeMuraCtrl(string ip, int port = 1600)
        {
            this.IP = ip;
            this.Port = port;
            Init();
        }

        ~SZPGDeMuraCtrl()
        {
            if (_handle != null && _handle != IntPtr.Zero)
            {
                Exit();
            }
        }

        public int DeMuraFlashWrite()
        {
            return (int)PGCtrlAPI.SCPGCommDemuraProgram(_handle);
        }

        public int DeMuraFunctionSwitch(bool bOn)
        {
            return (int)PGCtrlAPI.SCPGCommDemuraFunctionCtrl(_handle, bOn);
        }

        public int DeMuraOTP(int flag)
        {
            throw new NotImplementedException();
        }

        public bool Init()
        {
            _handle = new IntPtr();
            return PGCtrlAPI.SCPGCommInit(ref _handle, this.IP, (uint)this.Port);
        }

        public int Exit()
        {
            PGCtrlAPI.SCPGCommExit(_handle);
            return 0;
        }

        public int GetPowerInfo(int channelIndex, out float[][] voltageInfo, out float[][] currentInfo)
        {
            TagPGVCParam vcInfo = new TagPGVCParam();
            int ret = PGCtrlAPI.SCPGCommReadVCParam(_handle, out vcInfo);
            currentInfo = new float[4][];
            voltageInfo = new float[4][];
            if (ret != 0) return ret;
            for (int i = 0; i < 4; i++)
            {
                TagPortVoltCurr portVCInfo = vcInfo.wData[i];
                voltageInfo[i][0] = portVCInfo.wVCh1;
                currentInfo[i][0] = portVCInfo.wCCh1;

                voltageInfo[i][1] = portVCInfo.wVCh2;
                currentInfo[i][1] = portVCInfo.wCCh2;

                voltageInfo[i][2] = portVCInfo.wVCh3;
                currentInfo[i][2] = portVCInfo.wCCh3;

                voltageInfo[i][3] = portVCInfo.wVCh4;
                currentInfo[i][3] = portVCInfo.wCCh4;

                currentInfo[i][4] = portVCInfo.wCCh5;
                voltageInfo[i][4] = portVCInfo.wVCh5;

                voltageInfo[i][5] = portVCInfo.wVCh6;
                currentInfo[i][5] = portVCInfo.wCCh6;

                voltageInfo[i][6] = portVCInfo.wVCh7;
                currentInfo[i][6] = portVCInfo.wCCh7;

                voltageInfo[i][7] = portVCInfo.wVCh8;
                currentInfo[i][7] = portVCInfo.wCCh8;
            }
            return 0;
        }

        public int GetResolution(ref int width, ref int height)
        {
            throw new NotImplementedException();
        }

        public int PowerOff()
        {
            return (int)PGCtrlAPI.SCPGCommPowerOff(_handle);
        }

        public int PowerOn()
        {
            return (int)PGCtrlAPI.SCPGCommPowerOn(_handle);
        }

        public int ReadFlashID(out int flashID)
        {
            flashID = 0;
            return (int)PGCtrlAPI.SCPGCommReadFlashID(_handle, ref flashID);
        }

        public int ReadICRegVal(int nAddre, int nLen, out byte[] regVal)
        {
            throw new NotImplementedException();
        }

        public int ReadPGRegValue(int addr, int offset, int length, out int[] data)
        {
            data = new int[] { };
            return PGCtrlAPI.SCPGCommReadPGRegData(_handle, (short)addr, (short)offset, ref data, length);
        }

        public int SendFileByFtp(string fileName)
        {
            string destFile = fileName.Substring(fileName.LastIndexOf("\\") + 1);
            return (int)PGCtrlAPI.SCPGCommSetFileToPG(_handle, fileName, destFile);
        }

        public int SetPattern(int index)
        {
            return (int)PGCtrlAPI.SCPGCommSetPattern(_handle, (byte)index);
        }

        public int SetRaster(byte r, byte g, byte b)
        {
            return (int)PGCtrlAPI.SCPGCommSetLevel(_handle, r, g, b);
        }

        public int ShowText(int posX, int posY, int FontSize, string Msg, Color color)
        {
            return (int)PGCtrlAPI.SCPGCommShowText(_handle, posX, posY, FontSize, Msg, Msg.Length, (uint)ColorTranslator.ToWin32(color));
        }

        public int WriteICRegValue(byte[] regAddr, byte[] regVal)
        {
            throw new NotImplementedException();
        }

        public int WritePGRegValue(int addr, int offset, int length, int[] data)
        {
            return PGCtrlAPI.SCPGCommWritePGRegData(_handle, (short)addr, (short)offset, ref data, length);
        }

        public int ChangeModule(string Filename, int nLen)
        {
            return (int)PGCtrlAPI.SCPGCommChangeModule(Handle, Filename, nLen);
        }

        public int ReadCheckSum(ref ushort nCheckSum)
        {
            return (int)PGCtrlAPI.SCPGCommReadFlashChecksum(Handle, ref nCheckSum);
        }

        public int DmrEffectCtrl(bool bOn)
        {
            return (int)PGCtrlAPI.SCPGCommDemuraFunctionCtrl(Handle, bOn);
        }

        public int EraseFlash()
        {
            return (int)PGCtrlAPI.SCPGCommEraseFlash(Handle);
        }

        public int WriteFlash(string SPath)
        {
            return (int)PGCtrlAPI.SCPGCommDemuraDataTransfer(Handle, SPath);
        }
    }
}