using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    public enum ResultCompareMode
    {
        StringEqual,
        ResultContained,
        ResultContainString
    }
    public class ComPort:IDisposable
    {
        #region properties
        private SerialPort serialPort;
        private string RecievedMessage;
        private AutoResetEvent recieveEvent=new AutoResetEvent (false);

        public bool IsOpen {
            get
            {
                if (serialPort==null)
                {
                    return false;
                }
                return serialPort.IsOpen;
            }
        }
        #endregion

        public ComPort(string port, int baud)
        {
            serialPort = new SerialPort(port, baud);
            serialPort.DataReceived += SerialPort_DataReceived;
        }
        ~ComPort()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            serialPort.Dispose();
        }
        public void Open()
        {
            serialPort.Open();
        }


        public string SendMessage(string msg, int msTimeout)
        {
            RecievedMessage = "";
            recieveEvent.Reset();
            serialPort.Write(msg);
            recieveEvent.WaitOne(msTimeout);
            return RecievedMessage;
        }
        public bool SendMessage(string msg, out string recievedMsg, string resultCompareString,ResultCompareMode compareMode,int msTimeout)
        {
            RecievedMessage = "";
            recieveEvent.Reset();
            serialPort.Write(msg);
            recieveEvent.WaitOne(msTimeout);
            recievedMsg = RecievedMessage;
            if (recievedMsg == "")
            {
                return false;
            }
            bool bRet = false;  
            switch (compareMode)
            {
                case ResultCompareMode.StringEqual:
                    {
                        if (recievedMsg==resultCompareString)
                        {
                            bRet = true;    
                        }
                        break;
                    }
                case ResultCompareMode.ResultContained:
                    {

                        if ( resultCompareString.Contains(recievedMsg))
                        {
                            bRet = true;
                        }
                    }
                    break;
                case ResultCompareMode.ResultContainString:
                    {

                        if (recievedMsg.Contains(resultCompareString))
                        {
                            bRet = true;
                        }
                    }
                    break;
                default:
                    break;
            }
            return bRet;
        }
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
             RecievedMessage += serialPort.ReadExisting();

             recieveEvent.Set();
        }

        public void Dispose()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            serialPort.Dispose();
        }
    }
}
