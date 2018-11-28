using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Common;

namespace GifAnimation
{
    public class GifRun
    {
        public static string TEXT = "EnskyTools.GifAnimation.GifRun";

        /// <summary>
        /// Run a process for gif animation show, or any picture in a no border form.
        /// There has 4 kinds of call in arguments
        /// 1. FormText, GifPath, HintText.
        /// 2. FormText, GifPath => default HintText.
        /// 3. GifPath, => default FormText and HintText.
        /// 4. Default using bb.gif, default HintText and defauld text
        /// </summary>
        /// <param name="args">FormText: Form Title, GifPath: picture file path, HintText: Inform Message above picture</param>
        public static void Main(string[] args)
        {
            if (args.Length > 2)
            {
                //argument mode 
                //define arg[0] is a Text
                //define args[1] is gif path
                //define arg[2] is a hint in label
                try
                {
                    string text = args[0];
                    string gifPath = args[1];
                    string hintText = args[2];

                    //send picture file path to GifShow main form to show picture
                    GifShow gifBox = new GifShow(gifPath);
                    //set form text
                    gifBox.Text = text;
                    //set hint text words
                    gifBox.setHintText(hintText);

                    //run mian form as a application
                    Application.Run(gifBox);
                }
                catch (Exception e)
                {
                    //if error here will show fail message 
                    MessageBox.Show("Failed:" + e.Message, "Error");
                }
            }
            else if (args.Length == 2)
            {
                //argument mode 
                //define arg[0] is a Text
                //define args[1] is gif path
                try
                {
                    string text = args[0];
                    string gifPath = args[1];

                    //send picture file path to GifShow main form to show picture
                    GifShow gifBox = new GifShow(gifPath);
                    //set form text
                    gifBox.Text = text;

                    //run mian form as a application
                    Application.Run(gifBox);
                }
                catch (Exception e)
                {
                    //if error here will show fail message 
                    MessageBox.Show("Failed:" + e.Message, "Error");
                }
            }
            else if (args.Length == 1)
            {
                //argument mode 
                //define args[0] is gif path
                try
                {
                    string gifPath = args[0];

                    //send picture file path to GifShow, main form to show picture
                    GifShow gifBox = new GifShow(gifPath);
                    //using default TEXT
                    gifBox.Text = TEXT;

                    //run mian form as a application
                    Application.Run(gifBox);
                }
                catch (Exception e)
                {
                    //if error here will show fail message 
                    MessageBox.Show("Failed:" + e.Message, "Error");
                }
            }
            else
            {           
                try
                {
                    //here set a config file AnimationConfig by "Aniamtion" key and "GIF_FILE" field, it can set default picture file     
                    //send picture file path to GifShow, main form to show picture
                    GifShow gifBox = new GifShow(IniHelper.GetIniString("Animation", "GIF_FILE" ,"./Animation/Config.ini"));
                    //using default TEXT
                    gifBox.Text = TEXT; 

                    //run mian form as a application
                    Application.Run(gifBox);
                }
                catch (Exception e)
                {
                    //if error here will show fail message 
                    MessageBox.Show("Failed:" + e.Message, "Error");
                }
            }
        }
    }
}