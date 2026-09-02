// ===========================================================================================================  1:21 PM
//    FILENAME: DuSplash.xaml.cs
//       BUILD: 20191023
//     PROJECT: Du (https://github.com/APrettyCoolProgram/Du)
//     AUTHORS: development@aprettycoolprogram.com
//   COPYRIGHT: Copyright 2019 A Pretty Cool Program
//     LICENSE: Apache License, Version 2.0
// ====================================================================================================================

using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Du
{
    /// <summary>
    /// Interaction logic for DuSplash.xaml
    /// </summary>
    public partial class DuSplash : Window
    {
        /* You can create a splash screen that is larger/smaller than the default of 600x400, but it may result in
         * layout issues.
         *
         *  SplashHeight : The height of the splash (default = 400)
         *  SplashWidth  : The width of the splash (default = 600)
         *  SplashTitle  : The title bar text, currently not visible since the splash window has no window style
         */
        public double SplashHeight { get => Height; set => Height = value; }
        public double SplashWidth  { get => Width;  set => Width  = value; }
        public string SplashTitle  { get => Title;  set => Title  = value; }

        /* By changing the outer border background, you can create a 5px "border" around the popup window.
         *
         *  OuterBorderBackground : The background of the outer border (default = white)
         *  InnerBorderBackground : The background of the inner border (default = white)
         * */
        public Brush OuterBorderBackground { get => brdrOuter.Background; set => brdrOuter.Background = value; }
        public Brush InnerBorderBackground { get => brdrInner.Background; set => brdrInner.Background = value; }

        /*  ContentTitleText                : The text displayed at the top of the popup window
         *  ContentTitleHorizontalAlignment : The horizontal alignment of the title text (default = left)
         *  ContentTitleFontFamily          : The font family of the title text (default = Segoe UI)
         *  ContentTitleFontSize            : The font size of the title text (default = 20)
         *  ContentTitleBackground          : The background color of the title text (default = white)
         *  ContentTitleForeground          : The foreground color of the title text (default = black)
         * */
        public string              ContentTitleText                { get => tblkContentTitle.Text;                set => tblkContentTitle.Text                = value; }
        public HorizontalAlignment ContentTitleHorizontalAlignment { get => tblkContentTitle.HorizontalAlignment; set => tblkContentTitle.HorizontalAlignment = value; }
        public FontFamily          ContentTitleFontFamily          { get => tblkContentTitle.FontFamily;          set => tblkContentTitle.FontFamily          = value; }
        public double              ContentTitleFontSize            { get => tblkContentTitle.FontSize;            set => tblkContentTitle.FontSize            = value; }
        public Brush               ContentTitleBackground          { get => tblkContentTitle.Background;          set => tblkContentTitle.Background          = value; }
        public Brush               ContentTitleForeground          { get => tblkContentTitle.Foreground;          set => tblkContentTitle.Foreground          = value; }

        /*  ContentAppVersion : The application assembly version
         */
        public string ContentAppVersion { get => lblAppVersion.Content.ToString(); set => lblAppVersion.Content = value;}

        /*  ContentSubTitleText                : The text displayed at the top of the popup window
         *  ContentSubTitleHorizontalAlignment : The horizontal alignment of the sub title text (default = left)
         *  ContentSubTitleFontFamily          : The font family of the sub title text (default = Segoe UI)
         *  ContentSubTitleFontSize            : The font size of the sub title text (default = 20)
         *  ContentSubTitleBackground          : The background color of the sub title text (default = white)
         *  ContentSubTitleForeground          : The foreground color of the sub title text (default = black)
         * */
        public string              ContentSubTitleText                { get => tblkContentSubTitle.Text;                set => tblkContentSubTitle.Text                = value; }
        public HorizontalAlignment ContentSubTitleHorizontalAlignment { get => tblkContentSubTitle.HorizontalAlignment; set => tblkContentSubTitle.HorizontalAlignment = value; }
        public FontFamily          ContentSubTitleFontFamily          { get => tblkContentSubTitle.FontFamily;          set => tblkContentSubTitle.FontFamily          = value; }
        public double              ContentSubTitleFontSize            { get => tblkContentSubTitle.FontSize;            set => tblkContentSubTitle.FontSize            = value; }
        public Brush               ContentSubTitleBackground          { get => tblkContentSubTitle.Background;          set => tblkContentSubTitle.Background          = value; }
        public Brush               ContentSubTitleForeground          { get => tblkContentSubTitle.Foreground;          set => tblkContentSubTitle.Foreground          = value; }


        /*  ContentBodyText       : The text displayed in the center of the popup window
         *  ContentBodyBackground : The background color of the body text (default = white)
         *  ContentBodyForeground : The foreground color of the body text (default = black)
         */
        public string ContentBodyText       { get => tblkContentBody.Text;       set => tblkContentBody.Text       = value; }
        public Brush  ContentBodyBackground { get => tblkContentBody.Background; set => tblkContentBody.Background = value; }
        public Brush  ContentBodyForeground { get => tblkContentBody.Foreground; set => tblkContentBody.Foreground = value; }

        /* Popups have three "Action Buttons" at the bottom of the window. By default they are all hidden, so you
         * need to  make the Action Buttons that you are using visible when creating the popup.
         *
         *  ActionButton##Visibility : Visibility of ActionButton## (default = hidden)
         *  ActionButton##Content    : Content of ActionButton##
         *  ActionButton##Background : Background color of ActionButton## (default = white)
         *  ActionButton##Foreground : Foreground color of ActionButton## (default = black)
         */
        public Visibility ActionButton01Visibility { get => btnAction01.Visibility;      set => btnAction01.Visibility = value; }
        public string     ActionButton01Content    { get => (string)btnAction01.Content; set => btnAction01.Content    = value; }
        public Brush      ActionButton01Background { get => btnAction01.Background;      set => btnAction01.Background = value; }
        public Brush      ActionButton01Foreground { get => btnAction01.Foreground;      set => btnAction01.Foreground = value; }
        public Visibility ActionButton02Visibility { get => btnAction02.Visibility;      set => btnAction02.Visibility = value; }
        public string     ActionButton02Content    { get => (string)btnAction02.Content; set => btnAction02.Content    = value; }
        public Brush      ActionButton02Background { get => btnAction02.Background;      set => btnAction02.Background = value; }
        public Brush      ActionButton02Foreground { get => btnAction02.Foreground;      set => btnAction02.Foreground = value; }
        public Visibility ActionButton03Visibility { get => btnAction03.Visibility;      set => btnAction03.Visibility = value; }
        public string     ActionButton03Content    { get => (string)btnAction03.Content; set => btnAction03.Content    = value; }
        public Brush      ActionButton03Background { get => btnAction03.Background;      set => btnAction03.Background = value; }
        public Brush      ActionButton03Foreground { get => btnAction03.Foreground;      set => btnAction03.Foreground = value; }

        /// <summary>
        /// Customizable message popup window.
        /// </summary>
        public DuSplash()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Displays a custom error message.
        /// </summary>
        /// <param name="msgTitle">Ex: "File not found!"</param>
        /// <param name="msgBody">Ex: "The configuration file is either missing or corrupt.</param>
        public void Standard(string msgTitle, string msgSubTitle, string msgBody)
        {
            /* A simple error message popup that has a single "OK" button.
             */
            var errMsg = new DuSplash
            {
                ContentTitleText         = msgTitle,
                ContentAppVersion        = "v" + Assembly.GetExecutingAssembly().GetName().Version,
                ContentSubTitleText      = msgSubTitle,
                ContentBodyText          = msgBody,
                ActionButton01Visibility = Visibility.Hidden,
                ActionButton02Visibility = Visibility.Hidden,
                ActionButton03Visibility = Visibility.Visible,
                ActionButton03Content    = "OK",
            };
            errMsg.ShowDialog();
        }

        /// <summary>
        /// User clicks an ActionButton.
        /// </summary>
        /// <param name="sender">The ActionButton (i.e. "btnAction01").</param>
        private void ActionButtonClicked(object sender)
        {
            /* Each button can perform a number of preset actions, determined by their content. For example, if
             * ActionButton02.Content == "OK", the popup will close when ActionButton01 is clicked. The content is not
             * case sensitive, so an "OK" button and an "ok" button will both close the popup window.
             *
             * The preset actions are:
             *
             *  - OK       : Close the popup window
             *  - Continue : Close the popup window
             *  - Exit     : Exit the application immediately (and not gracefully!)
             */
            var btnAction = (Button)sender;

            switch (btnAction.Content.ToString().ToLower())
            {
                case "continue":
                case "ok":
                    Close();
                    break;

                case "exit":
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }

        /* Event handlers
         */
        private void BtnAction01_Click(object sender, RoutedEventArgs e) => ActionButtonClicked(sender);
        private void BtnAction02_Click(object sender, RoutedEventArgs e) => ActionButtonClicked(sender);
        private void BtnAction03_Click(object sender, RoutedEventArgs e) => ActionButtonClicked(sender);
    }
}