using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encryptor;

namespace EncryptorGUI
{
  public partial class Form1 : Form
  {
    MultiCipher multicipher = new MultiCipher();

    public Form1()
    {
      InitializeComponent();
      init();
    }

    void init()
    {
      lstAvailable.Items.Clear();
      lstSelected.Items.Clear();

      fillList();

      btnRemove.Click += btnRemove_Click;
      btnAdd.Click += btnAdd_Click;
      btnSwitch.Click += btnSwitch_Click;

      txtInput.TextChanged += txtInput_TextChanged;

      rdioDecrypt.CheckedChanged += rdio_CheckedChanged;
      rdioEncrypt.CheckedChanged += rdio_CheckedChanged;

      txtInput.Text = "This is just an example text.";
    }

    void btnSwitch_Click(object sender, EventArgs e)
    {
      txtInput.Text = txtOutput.Text;
      encrypt();
    }

    void rdio_CheckedChanged(object sender, EventArgs e)
    {
      encrypt();
    }

    void txtInput_TextChanged(object sender, EventArgs e)
    {
      encrypt();
    }

    void fillList()
    {
      lstAvailable.Items.Add(new PrintableAlgorithm(new CaesarCipher(1)));
      lstAvailable.Items.Add(new PrintableAlgorithm(new CaesarCipher(2)));
      lstAvailable.Items.Add(new PrintableAlgorithm(new CaesarCipher(3)));
      lstAvailable.Items.Add(new PrintableAlgorithm(new CaesarCipher(-1)));
      lstAvailable.Items.Add(new PrintableAlgorithm(new CaesarCipher(-2)));
      lstAvailable.Items.Add(new PrintableAlgorithm(new ReverseLang()));
      lstAvailable.Items.Add(new PrintableAlgorithm(new LeetLanguage()));
    }

    void encrypt()
    {
      multicipher = new MultiCipher();
      foreach (PrintableAlgorithm a in lstSelected.Items)
        multicipher.Add(a.Algorithm);

      if (rdioEncrypt.Checked)
        txtOutput.Text = multicipher.Encrypt(txtInput.Text);
      else
        txtOutput.Text = multicipher.Decrypt(txtInput.Text);
    }

    void btnAdd_Click(object sender, EventArgs e)
    {
      var selected = lstAvailable.SelectedItem;
      if (selected != null)
      {
        lstSelected.Items.Add(selected);
      }
      encrypt();
   }

    void btnRemove_Click(object sender, EventArgs e)
    {
      var selected = lstSelected.SelectedItem;
      if (selected != null)
      {
        lstSelected.Items.Remove(selected);
      }
      encrypt();
    }
  }

  class PrintableAlgorithm
  {
    public ILanguage Algorithm { get; private set; }

    public PrintableAlgorithm(ILanguage algorithm)
    {
      Algorithm = algorithm;
    }

    public override string ToString()
    {
      return Algorithm.GetName();
    }
  }
}
