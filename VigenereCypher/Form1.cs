using System;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace VigenereCypher
{
    public partial class Form1 : Form
    {
        string _chaves = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";


        int[] _pesoChave;

        public Form1()
        {
            InitializeComponent();

            InstanciaPesoChave();
            txtKey.Text = "GXYHJ1739";
            txtEncode.Text = "E13L25235959001";
        }

        private void InstanciaPesoChave()
        {
            _pesoChave = new int[_chaves.Length];

            for (var a = 0; a < _pesoChave.Length; a++)
            {
                var c = _chaves[a];
                if (c >= 'A' && c <= 'Z')
                {
                    _pesoChave[a] = 65;
                }
                else
                {
                    _pesoChave[a] = 48;
                }

            }
        }


        private void btnEncode_Click(object sender, EventArgs e)
        {
           txtDecode.Text = CryptDecrypt(encode: true, txtEncode.Text);
        }

        private string CryptDecrypt(bool encode, string stringCrypt)
        {
            int chave = 0;

            string key = txtKey.Text.ToUpper();
            string result = "";

            foreach (var item in stringCrypt)
            {
                var indexTexto = _chaves.IndexOf(item);

                var indexChave = _chaves.IndexOf(key[chave % key.Count()]);

                if (indexTexto < 0)
                {
                    result += item;
                }
                else
                {
                    int posicao = 0;
                    if (encode)
                    {
                        posicao = (indexTexto + indexChave) % 36;
                    } else
                    {
                        posicao = ((indexTexto - indexChave) + 36) % 36;
                    }

                    result += _chaves[posicao];
                }


                chave++;
            }

            return result;
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            txtEncode.Text = CryptDecrypt(encode: false, txtDecode.Text);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
