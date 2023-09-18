using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prova1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GerarListView();
        }

        private void GerarListView()
        {
            listView1.Columns.Add("Placa", 60).TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("Ano", 60).TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("Assentos", 60).TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("Eixos", 60).TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("Diaria", 60).TextAlign = HorizontalAlignment.Center;
            listView1.View = View.Details;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            maskedTextBox1.Mask = "aaa-0000";
            label3.Text = "Qtd Assentos";
            pictureBox1.Image = Properties.Resources.kisspng_bus_moscow_car_nancun_the_bus_5a6c294dcfa500_4179970015170379018505;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            maskedTextBox1.Mask = "aaa-0000";
            label3.Text = "Qtd Eixos";
            pictureBox1.Image = Properties.Resources.png_clipart_naberezhnye_chelny_kamaz_5460_car_kamaz_55111_volvo_freight_transport_truck;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool recebeValidacao = validaInformacao();
            if (radioButton1.Checked == true && recebeValidacao == true) //verifica se o rbPf esta marcado
            {
                Onibus onibus = new Onibus(maskedTextBox1.Text, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));

                string[] onibusCadastrado = new string[5];
                onibusCadastrado[0] = onibus.Placa;
                onibusCadastrado[1] = Convert.ToString(onibus.Ano);
                onibusCadastrado[2] = Convert.ToString(onibus.Assentos);
                onibusCadastrado[4] = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", onibus.Alugar());
                MensagemAluguel(onibus.Alugar());
                listView1.Items.Add(new ListViewItem(onibusCadastrado));
                MensagemBotao();
                Limpar();
            }
            else if (radioButton2.Checked == true && recebeValidacao == true)
            {
                Caminhao caminhao = new Caminhao(maskedTextBox1.Text, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));

                string[] caminhaoCadastrado = new string[5];
                caminhaoCadastrado[0] = caminhao.Placa;
                caminhaoCadastrado[1] = Convert.ToString(caminhao.Ano);
                caminhaoCadastrado[3] = Convert.ToString(caminhao.Eixos);
                caminhaoCadastrado[4] = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", caminhao.Alugar());
                MensagemAluguel(caminhao.Alugar());
                listView1.Items.Add(new ListViewItem(caminhaoCadastrado));
                MensagemBotao();
                Limpar();
            }
        }
        private void MensagemBotao()
        {
            MessageBox.Show("Dados Cadastrados com Sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MensagemBotao(string nomelabel)
        {
            MessageBox.Show("Voce deve preencher o campo: " + nomelabel + "!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensagemAluguel(double valorAluguel)
        {
            MessageBox.Show("O valor do aluguel diário é: " + valorAluguel.ToString("C2"), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool validaInformacao()
        {

            bool validaInfo = true;

            if (maskedTextBox1.MaskCompleted == false)
            {
                MensagemBotao(label1.Text);
                validaInfo = false;
            }
            else if (string.IsNullOrWhiteSpace(textBox1.Text)) 
            {
                MensagemBotao(label2.Text);
                validaInfo = false;
            }
            else if (!Regex.IsMatch(textBox1.Text, "^[0-9]+$"))
            {
                MensagemBotao("O campo Ano deve conter apenas números.");
                validaInfo = false;
            }
            else if (textBox2.Text.Trim() == string.Empty)
            {
                MensagemBotao(label3.Text);
                validaInfo = false;
            }
            else if (!Regex.IsMatch(textBox2.Text, "^[0-9]+$"))
            {
                MensagemBotao("O campo Qtd eixos/assentos deve conter apenas números.");
                validaInfo = false;
            }
            return validaInfo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Limpar();
        }
        private void Limpar()
        {
            maskedTextBox1.Text = string.Empty;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }
    }
}
