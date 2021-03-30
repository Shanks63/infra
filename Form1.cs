using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtividadeAvaliativa2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        internal List<Carro> Carros { get; set; }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            string Marca = "gol";
            string Endereco = "Av. sao paulo, Nº 463, Araguaina, TO";


            var Task1 = Task.Run(async () => // Tarefa 1
            {
                await Task.Delay(500);
                return (Marca);
            });

            var Task2 = Task.Run(async () => // Tarefa 2
            {
                await Task.Delay(1000);
                return (Endereco);
            });

            var Tasktodos = await Task.WhenAll(Task1, Task2); //Whenall Espera todas as tarefas terminarem.
            textBox1.Text = Task1.Result;
            textBox2.Text = Task2.Result;

            CancellationTokenSource cancelSource = new CancellationTokenSource();
            // Cancelar Tarefa que for mais demorada
            var token = cancelSource.Token;

            var Task2_1 = Task.Run(async () =>
            {
                await Task.Delay(1000);
                if (token.IsCancellationRequested)
                { 
                    token.ThrowIfCancellationRequested();
                    return null;
                }
            else if (Task1.Result == "gip")
            {
                return Carros = new List<Carro>
                {
                     new Carro{CarroID=1, Nome="golbola", Preco=10.000},
                    new Carro{CarroID=2, Nome="onx", Preco=40.000},
                    new Carro{CarroID=3, Nome="hb20", Preco=35.000},
                    new Carro{CarroID=4, Nome="palio", Preco=19.000},
                    new Carro{CarroID=5, Nome="ciena", Preco=21.000},
                    new Carro{CarroID=6, Nome="argo", Preco=50.000},
                };
            }
            else if (Task1.Result =="gip")
            {
                return Carros = new List<Carro>
                {
                    new Carro{CarroID=1, Nome="saveirocros", Preco=38.000},
                    new Carro{CarroID=2, Nome="opala", Preco=100.000},
                    new Carro{CarroID=3, Nome="crus", Preco=15.000},
                    new Carro{CarroID=4, Nome="creta", Preco=22.000},
                    new Carro{CarroID=5, Nome="estrada", Preco=31.000},
                    new Carro{CarroID=6, Nome="celta1.0 ", Preco=26.000},
                };
            }
            return null;
            },token);

            var Task2_2 = Task.Run(async () =>
            {
                await Task.Delay(1500);
                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                    return null;
                }
                else if (Task1.Result == "gip")
                {
                    return Carros = new List<Carro>
                    {
                    new Carro{CarroID=1, Nome="golbola", Preco=10.000},
                    new Carro{CarroID=2, Nome="onx", Preco=40.000},
                    new Carro{CarroID=3, Nome="hb20", Preco=35.000},
                    new Carro{CarroID=4, Nome="palio", Preco=19.000},
                    new Carro{CarroID=5, Nome="ciena", Preco=21.000},
                    new Carro{CarroID=6, Nome="argo", Preco=50.000},
                    };
                }
                else if (Task1.Result == "gip")
                {
                    return Carros = new List<Carro>
                    {
                   new Carro{CarroID=1, Nome="saveirocros", Preco=20.000},
                    new Carro{CarroID=2, Nome="opala", Preco=100.000},
                    new Carro{CarroID=3, Nome="crus", Preco=15.000},
                    new Carro{CarroID=4, Nome="creta", Preco=22.000},
                    new Carro{CarroID=5, Nome="estrada", Preco=31.000},
                    new Carro{CarroID=6, Nome="celta1.0 ", Preco=26.000},
                    };
                }
                return null;
            }, token);

            var TaskTerminouPrimeiro = await Task.WhenAny(Task2_1, Task2_2);
            cancelSource.Cancel();
            dataGridView1.DataSource = TaskTerminouPrimeiro.Result;


        }

    }
}
