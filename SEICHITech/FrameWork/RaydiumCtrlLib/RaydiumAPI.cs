using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RaydiumCtrlLib
{
    public enum eRadErr
    {
        No_Value = -1,
        File_Open = -2,
        Scientific_Notation = -3,
        Dot = -4,
        Width = -5,
        Height = -6,
        OK = 0,
        Path_Empty,
        Load_Dll_Failed,
        Get_FnAddr_Failed,
        Demura_Data_File,
    }

    public class RaydiumAPI
    {
        [DllImport("Raydium", EntryPoint = "DoCreateBin")]
        public static extern eRadErr DoCreateBin(string Path, string dmr_cfgFile, string sufix);

        [DllImport("Raydium", EntryPoint = "SetCSVDataPath")]
        public static extern void SetCSVDataPath(string StrPath);

        [DllImport("Raydium", EntryPoint = "SetPanelID")]
        public static extern void SetPanelID(string PanelID);

        [DllImport("Raydium", EntryPoint = "DoCreateBin")]
        public static extern eRadErr DoCreateBin(bool highPass = false);

        [DllImport("Raydium", EntryPoint = "ReadFileChecksum")]
        public static extern int ReadFileChecksum(string strPID, bool bSelectFile = false);

        [DllImport("Raydium", EntryPoint = "GetErrorStr")]
        public static extern string GetErrorStr(eRadErr nCode);
    }
}