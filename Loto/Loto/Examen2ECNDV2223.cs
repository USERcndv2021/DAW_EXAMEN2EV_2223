﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LotoClassNS;

namespace ExamenLoto
{
    public partial class Examen2ECNDV2223 : Form
    {
        public LotoCNDV2223 miLoto, miGanadora;
        private TextBox[] combinacion = new TextBox[6]; // Estos arrays se usan para recorrer de manera más sencilla los controles
        private TextBox[] ganadora = new TextBox[6];
        public Examen2ECNDV2223()
        {
            InitializeComponent();
            combinacion[0] = txtNumero1; ganadora[0] = txtGanadora1;
            combinacion[1] = txtNumero2; ganadora[1] = txtGanadora2;
            combinacion[2] = txtNumero3; ganadora[2] = txtGanadora3;
            combinacion[3] = txtNumero4; ganadora[3] = txtGanadora4;
            combinacion[4] = txtNumero5; ganadora[4] = txtGanadora5;
            combinacion[5] = txtNumero6; ganadora[5] = txtGanadora6;
            miGanadora = new LotoCNDV2223(); // generamos la combinación ganadora
            for (int i = 0; i < 6; i++)
            {
                ganadora[i].Text = Convert.ToString(miGanadora.Numeros[i]);
            }
        }

        private void btGenerar_Click(object sender, EventArgs e)
        {
            miLoto = new LotoCNDV2223(); // usamos constructor vacío, se genera combinación aleatoria
            for ( int i = 0; i < 6; i++ )
            {
                combinacion[i].Text = Convert.ToString(miLoto.Numeros[i]);
            }
        }

        private void btValidar_Click(object sender, EventArgs e)
        {
            int[] nums = new int[6];    
            for (int i = 0; i < 6; i++)
            {
                nums[i] = Convert.ToInt32(combinacion[i].Text);
            }

            miLoto = new LotoCNDV2223(nums);
            if (miLoto.ok)
            {
                MessageBox.Show("Combinación válida");
            }
            else
                MessageBox.Show("Combinación no válida");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btComprobar_Click(object sender, EventArgs e)
        {
            int[] nums = new int[6];
            for (int i = 0; i < 6; i++)
            {
                nums[i] = Convert.ToInt32(combinacion[i].Text);
            }

            miLoto = new LotoCNDV2223(nums);
            if (miLoto.ok)
            {
                nums = new int[6];
                for (int i = 0; i < 6; i++)
                {
                    nums[i] = Convert.ToInt32(combinacion[i].Text);
                }

                int aciertos = miGanadora.Comprobar(nums);
                if (aciertos < 3)
                {
                    MessageBox.Show("No ha resultado premiada");
                }
                else
                    MessageBox.Show("¡Enhorabuena! Tiene una combinación con " + Convert.ToString(aciertos) + " aciertos");
            }
            else
                MessageBox.Show("La combinación introducida no es válida");
        }
    }
}
