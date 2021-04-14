using System;
using System.Windows.Forms;

namespace BDSew
{
    public partial class DigitalInputForm : Form
    {
        public float Distance { get; set; }

        public DigitalInputForm()
        {
            InitializeComponent();
        }

        public DigitalInputForm(string desc)
            : this()
        {
            this.labTitle.Text = desc;
        }

        private void DigitalInputForm_Load(object sender, EventArgs e)
        {
            if (Distance < 0.1) Distance = 0.1f;
            this.txtValue.Text = textValue = this.Distance.ToString("f1");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Distance = Convert.ToSingle(txtValue.Text) ;

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        string textValue = "0";

        private bool HasDot()
        {
            return textValue.IndexOf('.') >= 0;
        }
        private bool EndsWithDot()
        {
            return textValue.EndsWith(".");
        }

        private bool CanInputDigital()
        {
            if (HasDot())
            {
                return EndsWithDot();
            }
            return true;
        }
        private bool CanInputDot()
        {
            if (HasDot())
            {
                return false;
            }
            return true;
        }


        private void btnDigital_1_Click(object sender, EventArgs e)
        {
            if (CanInputDigital())
            {
                this.txtValue.Text = textValue += 1;
            }
        }

        private void btnDigital_2_Click(object sender, EventArgs e)
        {
            if (CanInputDigital())
            {
                this.txtValue.Text = textValue += 2;
            }
        }

        private void btnDigital_3_Click(object sender, EventArgs e)
        {
            if (CanInputDigital())
            {
                this.txtValue.Text = textValue += 3;
            }
        }

        private void btnDigital_4_Click(object sender, EventArgs e)
        {
            if (CanInputDigital())
            {
                this.txtValue.Text = textValue += 4;
            }
        }

        private void btnDigital_5_Click(object sender, EventArgs e)
        {
            if (CanInputDigital())
            {
                this.txtValue.Text = textValue += 5;
            }
        }

        private void btnDigital_6_Click(object sender, EventArgs e)
        {
            if (CanInputDigital())
            {
                this.txtValue.Text = textValue += 6;
            }
        }

        private void btnDigital_7_Click(object sender, EventArgs e)
        {
            if (CanInputDigital())
            {
                this.txtValue.Text = textValue += 7;
            }
        }

        private void btnDigital_8_Click(object sender, EventArgs e)
        {
            if (CanInputDigital())
            {
                this.txtValue.Text = textValue += 8;
            }
        }

        private void btnDigital_9_Click(object sender, EventArgs e)
        {
            if (CanInputDigital())
            {
                this.txtValue.Text = textValue += 9;
            }
        }

        private void btnDigital_0_Click(object sender, EventArgs e)
        {
            if (CanInputDigital())
            {
                this.txtValue.Text = textValue += 0;
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (CanInputDot())
            {
                this.txtValue.Text = textValue += '.';
            }
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            if (textValue.Length > 0)
            {
                this.txtValue.Text = textValue = textValue.Substring(0, textValue.Length - 1);
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            textValue = "";
            this.txtValue.Text = textValue;
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            Distance = Convert.ToSingle(textValue);
            if (Distance > 0.1f)
            {
                Distance -= 0.1f;
            }

            textValue = Distance.ToString("f1");
            this.txtValue.Text = textValue;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Distance = Convert.ToSingle(textValue);
            Distance+=0.1f;

            textValue = Distance.ToString("f1");
            this.txtValue.Text = textValue;
        }
    }
}
