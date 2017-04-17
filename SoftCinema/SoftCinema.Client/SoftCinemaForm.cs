﻿using SoftCinema.Client.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using SoftCinema.Client.Forms.AdminForms;
using SoftCinema.Models;
using SoftCinema.Services;
using SoftCinema.Services.Utilities;

namespace SoftCinema.Client
{
    public partial class SoftCinemaForm : Form
    {
        public SoftCinemaForm()
        {
            InitializeComponent();
        }

        private void SoftCinemaForm_Load(object sender, EventArgs e)
        {
            loadTopPanelForm();
        }

        private void loadTopPanelForm()
        {
            TopPanelForm topPanel = new TopPanelForm();
            topPanel.TopLevel = false;
            topPanel.AutoScroll = true;
            this.TopPanel.Controls.Clear();
            this.TopPanel.Controls.Add(topPanel);
            topPanel.Show();
        }

        //Sidebar buttons
        private void registerTeamButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.TopLevel = false;
            registerForm.AutoScroll = true;
            this.ContentHolder.Controls.Clear();            
            this.ContentHolder.Controls.Add(registerForm);            
            registerForm.Show();
        }
        
        
        private void loginTeamButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.TopLevel = false;
            loginForm.AutoScroll = true;
            this.ContentHolder.Controls.Clear();
            this.ContentHolder.Controls.Add(loginForm);
            loginForm.Show();
        }

        private void registerMovie_Click(object sender, EventArgs e)
        {
            RegisterMovieForm registerMovieForm = new RegisterMovieForm();
            registerMovieForm.TopLevel = false;
            registerMovieForm.AutoScroll = true;
            this.ContentHolder.Controls.Clear();
            this.ContentHolder.Controls.Add(registerMovieForm);
            registerMovieForm.Show();
        }

        private void buyTicketsTeamButton_Click(object sender, EventArgs e)
        {
            TicketForm ticketForm = new TicketForm();
            ticketForm.TopLevel = false;
            ticketForm.AutoScroll = true;
            this.ContentHolder.Controls.Clear();
            this.ContentHolder.Controls.Add(ticketForm);
            ticketForm.Show();
        }

        private void AdminMenu_Click(object sender, EventArgs e)
        {
            AdminMenuForm adminMenuForm = new AdminMenuForm();
            adminMenuForm.TopLevel = false;
            adminMenuForm.AutoScroll = true;
            this.ContentHolder.Controls.Clear();
            this.ContentHolder.Controls.Add(adminMenuForm);
            adminMenuForm.Show();
        }

        private void testMoviesButton_Click(object sender, EventArgs e)
        {
            MoviesForm moviesForm = new MoviesForm();
            moviesForm.TopLevel = false;
            moviesForm.AutoScroll = true;
            this.ContentHolder.Controls.Clear();
            this.ContentHolder.Controls.Add(moviesForm);
            moviesForm.Show();
        }


        private void testSeatsButton_Click(object sender, EventArgs e)
        {
            var hardcoded = ScreeningService.GetScreening("Plovdiv", "SoftCinema", "Logan",
                new DateTime(2017, 4, 21, 16, 0, 0));

            //mega hardcode
            SelectSeatsForm selectSeatsForm = new SelectSeatsForm(hardcoded,3);
            selectSeatsForm.Show();
        }
    }
}