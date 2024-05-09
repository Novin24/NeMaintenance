﻿using System.Windows.Controls;

namespace NeMaintenancePrj.Controls
{

    public partial class PersianDatePicker : UserControl
    {
        public event RoutedEventHandler PopupClosed;
        public PersianDatePicker()
        {
            InitializeComponent();
            txt_date.Text = persianCalendar.PersianSelectedDate;
        }

        #region LableName
        public string LabelName
        {
            get { return (string)GetValue(LableNameProperty); }
            set { SetValue(LableNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LableName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LableNameProperty =
            DependencyProperty.Register("LableName", typeof(string), typeof(PersianDatePicker), new PropertyMetadata(string.Empty, SetLabelName));

        private static void SetLabelName(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (obj is not PersianDatePicker npack)
                return;

            if (e.NewValue == e.OldValue)
                return;

            npack.lbl_name.Text = e.NewValue.ToString();
        }
        #endregion

        #region SelectedDate
        /// <summary>
        /// تاریخ انتخاب شده
        /// </summary>
        public DateTime? SelectedDate
        {
            get { return (DateTime?)GetValue(SelectedDateProperty); }
            set
            {
                SetValue(SelectedDateProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for SelectedDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedDateProperty =
            DependencyProperty.Register("SelectedDate", propertyType: typeof(DateTime?), typeof(PersianDatePicker)
                , new FrameworkPropertyMetadata(null
                , new PropertyChangedCallback(OnPropertyChanged)));
        #endregion

        #region DisplayDate

        /// <summary>
        /// تاریخ قابل نمایش فارسی
        /// </summary>
        public string DisplayDate
        {
            get { return (string)GetValue(DisplayDateProperty); }
            set { SetValue(DisplayDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayDateProperty =
            DependencyProperty.Register("DisplayDate", typeof(string), typeof(PersianDatePicker), new PropertyMetadata(string.Empty, SetDate));

        private static void SetDate(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (obj is not PersianDatePicker pdp)
                return;

            if (args.NewValue == args.OldValue)
                return;

            pdp.txt_date.Text = args.NewValue.ToString();
        }

        #endregion

        #region Event
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            persianCalnedarPopup.IsOpen = true;
        }

        private void PersianCalnedarPopup_Opened(object sender, EventArgs e)
        {
            this.persianCalendar.Focus();
        }

        private void PersianCalendar_Click(object sender, RoutedEventArgs e)
        {
            persianCalnedarPopup.IsOpen = false;
            PopupClosed?.Invoke(sender, e);
            txt_date.Focus();
        }

        private void Dismiss_Click(object sender, RoutedEventArgs e)
        {
            txt_date.Clear();
            SelectedDate = null;
        }
        private void Btn_SelectToday_Click(object sender, RoutedEventArgs e)
        {
            SelectedDate = DateTime.Now;
        }
        #endregion

        #region CustomeEvent
        /// <summary>
        /// Event occurs when the user selects an item from the recommended ones.
        /// </summary>
        public event RoutedPropertyChangedEventHandler<DateTime?> DateChosen
        {
            add => AddHandler(DateChosenEvent, value);
            remove => RemoveHandler(DateChosenEvent, value);
        }

        /// <summary>
        /// Routed event for <see cref="DateChosen"/>.
        /// </summary>
        public static readonly RoutedEvent DateChosenEvent = EventManager.RegisterRoutedEvent(
            nameof(DateChosen),
            RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<DateTime?>),
            typeof(PersianDatePicker)
        );


        private static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            if (sender is PersianDatePicker c)
            {
                RoutedPropertyChangedEventArgs<DateTime?> e = new(args.OldValue == null ? null : (DateTime)args.OldValue, args.NewValue == null ? null : (DateTime)args.NewValue, DateChosenEvent);
                c.OnDateChanged(e);
            }
        }

        protected virtual void OnDateChanged(RoutedPropertyChangedEventArgs<DateTime?> args)
        {
            RaiseEvent(args);
        }

        #endregion

    }
}
