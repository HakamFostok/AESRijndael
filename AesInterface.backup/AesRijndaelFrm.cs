using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using AesRijndaelLibrary;

namespace AesInterface
{
    public partial class FrmAesRijndael : Form
    {
        private AesInterface.Properties.Settings currentSettings { get; set; }
        private static Dictionary<Control, Tuple<string, string>> textValuesOfControl { get; set; }
        private List<Tuple<AesBase, AesKeyBase, int, string>> algorithms { get; set; }
        private int Index { get; set; }

        private Tuple<AesBase, AesKeyBase, int, string> SelectedTuple
        {
            get
            {
                return algorithms[Index];
            }
        }

        public FrmAesRijndael()
        {
            InitializeComponent();

            textValuesOfControl = new Dictionary<Control, Tuple<string, string>>
            {
                { lblCipher , new Tuple<string, string>("النص المشفر","Cipher Text") },
                { lblPlainText , new Tuple<string, string>("النص الواضح","Plain Text") },
                { lblKey , new Tuple<string, string>("قيم ست عشرية", "hexadecimal") },
                { grpBxLang , new Tuple<string, string>("اللغة", "Language") },
                { grpBxKey , new Tuple<string, string>("المفتاح", "Key") },
                { grpBxEncDec , new Tuple<string, string>("العملية", "Operation") },
                { grpBxAESKind , new Tuple<string, string>("نوع الخورازمية", "Kind of Algorithm") },
                { rdbtnAES128 ,new Tuple<string, string>("AES 128", "AES 128") },
                { rdbtnAES192 , new Tuple<string, string>("AES 192", "AES 192") },
                { rdbtnAES256 ,new Tuple<string, string>("AES 256", "AES 256") },
                { rdbtnArabic , new Tuple<string, string>("عربي", "Arabic") },
                { rdbtnEnglish , new Tuple<string, string>("انكليزي", "English") },
                { rdbtnDecrypt ,new Tuple<string, string>("فك التشفير", "Decrypt") },
                { rdbtnEncrpyt ,new Tuple<string, string>("تشفير", "Encrypt") },
                { grpBxText , new Tuple<string, string> ("النص", "Text")},
                { lblMaxLength , new Tuple<string, string>("طول المفتاح","Key Length") },
                { btnEncryptDecrypt, new Tuple<string, string> ("تشفير / فك تشفير","Encrypt / Decrypt") },
                { btnAbout, new Tuple<string, string>("حول البرنامج","About Porgram")},
                { btnClear, new Tuple<string, string>("مسح", "Clear")},
                { btnFormat , new Tuple<string, string>("تنسيق","Format") },
                { btnFont , new Tuple<string,string> ("الخط","Font") }
            };
            
            algorithms = new List<Tuple<AesBase, AesKeyBase, int, string>> 
            {
                new Tuple<AesBase, AesKeyBase, int, string>(new Aes128(), new AesKey128(), 32, "000102030405060708090a0b0c0d0e0f"),
                new Tuple<AesBase, AesKeyBase, int, string>(new Aes192(), new AesKey192(), 48, "000102030405060708090a0b0c0d0e0f1011121314151617"),
                new Tuple<AesBase, AesKeyBase, int, string>(new Aes256(), new AesKey256(), 64, "000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f") 
            };

            currentSettings = new Properties.Settings();

            if (!currentSettings.AesLanguage)
            {
                rdbtnArabic.Checked = true;
            }
            else
            {
                rdbtnEnglish.Checked = true;
            }

            SetFontToRichTextBoxes(currentSettings.AesFont);
            txtbxKey.MaxLength = SelectedTuple.Item3;
            rdbtnEncrpyt_CheckedChanged(rdbtnEncrpyt, new EventArgs());
            ChangeKeyLength();
        }

        private void SetFontToRichTextBoxes(Font font)
        {
            richtxtCipher.Font = font;
            richtxtPlain.Font = font;
        }

        private void ChangeKeyLength()
        {
            if (rdbtnArabic.Checked)
            {
                lblMaxLength.Text = SelectedTuple.Item3 + " : " + textValuesOfControl[lblMaxLength].Item1;
            }
            else
            {
                lblMaxLength.Text = textValuesOfControl[lblMaxLength].Item2 + " : " + SelectedTuple.Item3;
            }
        }

        private void LoadLanguageOnForm(Language lang)
        {
            Action<Control> setText = (control) =>
            {
                switch (lang)
                {
                    case Language.Arabic:
                        control.Text = textValuesOfControl[control].Item1;
                        break;

                    case Language.English:
                        control.Text = textValuesOfControl[control].Item2;
                        break;

                    default:
                        break;
                }
            };

            foreach (Control container in this.Controls.OfType<GroupBox>())
            {
                setText(container);
                foreach (Control control in container.Controls)
                {
                    if (control is Label || control is RadioButton || control is Button)
                    {
                        setText(control);
                    }
                }
            }

            setText(lblCipher);
            setText(lblPlainText);
        }

        private void rdbtnLanguage_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rad = (RadioButton)sender;
            int tag = Convert.ToInt32(rad.Tag);
            LoadLanguageOnForm((Language)tag);
            // it is very necessary the steps of these statment;
            ChangeKeyLength();
            currentSettings.AesLanguage = Convert.ToBoolean(tag);
        }

        private void btnEncryptDecrypt_Click(object sender, EventArgs e)
        {
            // Handle the key.
            byte[] bytesOfKey;
            try
            {
                bytesOfKey = HandleTheKey();
            }
            catch (KeyNotFoundException)
            {
                ShowError("Char is not valid.\nThe valid char is :\na, b, c, d, e, f");
                return;
            }

            // Handle The Ecrypt Decrypt Operation.

            if (rdbtnEncrpyt.Checked)
            {
                Process(richtxtPlain, richtxtCipher, true);
            }
            else
            {
                Process(richtxtCipher, richtxtPlain, false);
            }
        }

        private void Process(RichTextBox source, RichTextBox distination, bool encryptFlag)
        {
            FormatRichTextBox(source);
            byte[] bytesOfText = HandleTheInput(source);

            List<byte[]> totalOutput = new List<byte[]>();

            // handle the cipher.
            for (int index = 0; index < bytesOfText.Length / 16; index++)
            {
                if (encryptFlag)
                {
                    totalOutput.Add(SelectedTuple.Item1.Encrypt(bytesOfText.Skip(16 * index).Take(16).ToArray(), SelectedTuple.Item2));
                }
                else
                {
                    totalOutput.Add(SelectedTuple.Item1.Decrypt(bytesOfText.Skip(16 * index).Take(16).ToArray(), SelectedTuple.Item2));
                }
            }

            distination.Lines = totalOutput.Select(oneByte => oneByte.Select(b => b.GetHexadecimal()).Aggregate((one, two) => one + two)).ToArray();
        }

        private byte[] HandleTheInput(RichTextBox source)
        {
            List<byte> bytesOfText = new List<byte>();

            string text = source.Lines.Select(line => new string(line.Where(ch => !char.IsWhiteSpace(ch)).ToArray())).Aggregate((one, two) => one + two);
            GetHexadecimal(bytesOfText, text);

            // make the length of the bytes array multiplied by 16.
            while ((bytesOfText.Count % 16) != 0)
            {
                bytesOfText.Add(0);
            }

            return bytesOfText.ToArray();
        }

        private byte[] HandleTheKey()
        {
            // get the key
            List<byte> bytesOfKey = new List<byte>();

            txtbxKey.Text = txtbxKey.Text.Select(b => b.ToString()).Concat(Enumerable.Repeat<int>(0, SelectedTuple.Item3 - txtbxKey.Text.Length).Select(i => i.ToString())).Aggregate((one, two) => one + two);
            SelectedTuple.Item2.Subkeys = bytesOfKey;
            GetHexadecimal(bytesOfKey, txtbxKey.Text);

            return bytesOfKey.ToArray();
        }

        private static void GetHexadecimal(List<byte> bytes, string text)
        {
            try
            {
                for (int index = 0; index < text.Length; index += 2)
                {
                    bytes.Add(text.Substring(index, 2).GetByteFromHex());
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                bytes.Add(text[text.Length - 1].ToString().GetByteFromHex());
            }
        }

        private static void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void rdbtnAESAlgo_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rad = (RadioButton)sender;
            if (rad.Checked)
            {
                int tag = Convert.ToInt32(rad.Tag);
                txtbxKey.Clear();
                txtbxKey.MaxLength = algorithms[tag].Item3;
                Index = tag;
            }

            ChangeKeyLength();
            txtbxKey.Text = SelectedTuple.Item4;
            richtxtCipher.Text = "";
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            new AboutFrm().ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            richtxtCipher.Text = "";
            richtxtPlain.Text = "";
        }

        private void rdbtnEncrpyt_CheckedChanged(object sender, EventArgs e)
        {
            SetRichTextReadOnlyStatu((RadioButton)sender, richtxtCipher, richtxtPlain);
        }

        private void rdbtnDecrypt_CheckedChanged(object sender, EventArgs e)
        {
            SetRichTextReadOnlyStatu((RadioButton)sender, richtxtPlain, richtxtCipher);
        }

        private void SetRichTextReadOnlyStatu(RadioButton sender, RichTextBox first, RichTextBox second)
        {
            if (sender.Checked)
            {
                second.ReadOnly = false;
                second.BackColor = SystemColors.Window;

                first.ReadOnly = true;
                first.BackColor = SystemColors.Control;
            }
        }

        private void btnFormat_Click(object sender, EventArgs e)
        {
            if (rdbtnEncrpyt.Checked)
            {
                FormatRichTextBox(richtxtPlain);
            }
            else if (rdbtnDecrypt.Checked)
            {
                FormatRichTextBox(richtxtCipher);
            }
        }

        private void FormatRichTextBox(RichTextBox source)
        {
            if (source.Text.Trim() != "")
            {
                List<string> totalInput = new List<string>();
                string textOfInput = source.Lines.Select(line => new string(line.Where(c => !char.IsWhiteSpace(c)).ToArray())).Aggregate((one, two) => one + two);
                if (textOfInput.Length % 32 != 0)
                {
                    textOfInput = textOfInput + new string(Enumerable.Repeat<char>('0', 32 - (textOfInput.Length % 32)).ToArray());
                }

                for (int index = 0; index < textOfInput.Length / 32; index++)
                {
                    totalInput.Add(new string(textOfInput.Skip(32 * index).Take(32).ToArray()));
                }

                source.Lines = totalInput.ToArray();
            }
        }

        private void FrmAesRijndael_FormClosing(object sender, FormClosingEventArgs e)
        {
            currentSettings.Save();
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            fontDialogText.ShowDialog();
            SetFontToRichTextBoxes(fontDialogText.Font);
            currentSettings.AesFont = fontDialogText.Font;
        }
    }
}