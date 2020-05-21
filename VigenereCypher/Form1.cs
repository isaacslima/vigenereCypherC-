using System;
using System.Linq;
using System.Windows.Forms;

namespace VigenereCypher
{
    public partial class Form1 : Form
    {
        string _chaves = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public Form1()
        {
            InitializeComponent();
            txtChaves.Text = _chaves;
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
           txtDecode.Text = CryptDecrypt(encode: true, encDecString: txtEncode.Text, key: txtKey.Text);
        }

        private string CryptDecrypt(bool encode, string encDecString, string key)
        {
            txtChaves.Text = _chaves;

            int chave = 0;

            string result = "";

            foreach (var item in encDecString)
            {
                var indexTexto = _chaves.IndexOf(item);

                var indexChave = _chaves.IndexOf(key[chave % key.Count()]);

                if (indexTexto < 0)
                {
                    result += item;
                    continue;
                }
                else
                {
                    int posicao = 0;
                    if (encode)
                    {
                        posicao = (indexTexto + indexChave) % _chaves.Count();
                    } else
                    {
                        posicao = ((indexTexto - indexChave) + _chaves.Count()) % _chaves.Count();
                    }

                    result += _chaves[posicao];
                }
                chave++;
            }

            return result;
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            txtEncode.Text = CryptDecrypt(encode: false, encDecString: txtDecode.Text, key: txtKey.Text);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAlterarChaves_Click(object sender, EventArgs e)
        {
            _chaves = txtChaves.Text;
        }
    }
}
