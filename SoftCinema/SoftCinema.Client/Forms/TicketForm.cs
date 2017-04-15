﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftCinema.Client.Forms
{
    public partial class TicketForm : Form
    {
        public TicketForm()
        {
            InitializeComponent();
            this.townComboBox.Items.AddRange(Services.TownService.GetTownsNames());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

//        private void Ticket_Load(object sender, EventArgs e)
//        {
//            // TODO: This line of code loads data into the 'softCinemaDataSet2.Movies' table. You can move, or remove it, as needed.
//            this.moviesTableAdapter.Fill(this.softCinemaDataSet2.Movies);
//            // TODO: This line of code loads data into the 'softCinemaDataSet1.Cinemas' table. You can move, or remove it, as needed.
//            this.cinemasTableAdapter.Fill(this.softCinemaDataSet1.Cinemas);
//            // TODO: This line of code loads data into the 'softCinemaDataSet.Towns' table. You can move, or remove it, as needed.
//            this.townsTableAdapter.Fill(this.softCinemaDataSet.Towns);
//
//        }

        private void townComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cinemaComboBox.Text = "Select cinema";
            this.cinemaComboBox.Items.Clear();
            this.movieComboBox.Text = "";
            this.movieComboBox.Items.Clear();
            this.dateComboBox.Text = "";
            this.dateComboBox.Items.Clear();
            this.timeComboBox.Text = "";
            this.timeComboBox.Items.Clear();
            this.cinemaComboBox.Items.AddRange(Services.CinemaService.GetCinemasNamesBySelectedTown(this.townComboBox.SelectedItem.ToString()));
            if (this.cinemaComboBox.Items.Count == 0)
            {
                this.cinemaComboBox.Text="(no cinemas)";
                
            }
        }

        private void selectSeats_Click(object sender, EventArgs e)
        {
            TicketTypeForm ticketTypeForm = new TicketTypeForm();
            ticketTypeForm.TopLevel = false;
            ticketTypeForm.AutoScroll = true;
            this.Hide();
             ((Button)sender).Parent.Parent.Controls.Add(ticketTypeForm);
            ticketTypeForm.Show();


        }

        private void cinemaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                this.movieComboBox.Text = "Select movie";
                this.movieComboBox.Items.Clear();
                this.movieComboBox.Items.AddRange(
                    Services.MovieService.GetMoviesNamesByCinema(this.cinemaComboBox.SelectedItem.ToString(),
                        this.townComboBox.SelectedItem.ToString()));
                if (this.movieComboBox.Items.Count == 0)
                {
                    this.movieComboBox.Text = "(no movies)";
                }
            }

        private void movieComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dateComboBox.Text = "Select date";
            this.dateComboBox.Items.Clear();
            this.dateComboBox.Items.AddRange(
                Services.ScreeningService.GetAllDates(this.townComboBox.SelectedItem.ToString(),this.cinemaComboBox.SelectedItem.ToString(),this.movieComboBox.SelectedItem.ToString()
                    ));
            
        }

        private void timeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.timeComboBox.Text = "Select time";
            this.timeComboBox.Items.Clear();
            this.timeComboBox.Items.AddRange(
                Services.ScreeningService.GetHoursForMoviesByDate(this.townComboBox.SelectedItem.ToString(), this.cinemaComboBox.SelectedItem.ToString(), this.movieComboBox.SelectedItem.ToString(),this.dateComboBox.SelectedItem.ToString()
                    ));
        }
    }
}
