using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAuction.App_Code;
using System.Timers;


namespace WebAuction
{
    public partial class _default : System.Web.UI.Page
    {

        protected Item _watch;
        protected Item _watch2;
        protected Item _watch3;


        //public void InitTimer(int minutes)
        //{
        //    Session.Add("timer", minutes);
        //    Timer1.Enabled = true;


        //}
        int currentTime = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //{
                //    myAuction = Initialise(myAuction);
                //}
                Session["_watch"] = new Item();
                Item _watch = Session["_Watch"] as Item;

                _watch.name = "Rolex";
                _watch.description = "Vintage 1970s Rolex Oyster Perpetual";
                _watch.reservedPrice = 300;
                _watch.yourBid = 0;
                _watch.currentBid = 0;
                _watch.highestBid = 200;


                Session["_watch2"] = new Item();
                Item _watch2 = Session["_Watch2"] as Item;

                _watch2.name = "Chanel";
                _watch2.description = "Chanel J12 White Unisex Watch";
                _watch2.reservedPrice = 500;
                _watch2.yourBid = 0;
                _watch2.currentBid = 0;
                _watch2.highestBid = 900;

                Session["_watch3"] = new Item();
                Item _watch3 = Session["_Watch3"] as Item;

                _watch3.name = "Omega";
                _watch3.description = "Omega SeaMaster 300";
                _watch3.reservedPrice = 500;
                _watch3.yourBid = 0;
                _watch3.currentBid = 0;
                _watch3.highestBid = 4000;


                ListBox1.Items.Add(_watch.name);
                ListBox1.Items.Add(_watch2.name);
                ListBox1.Items.Add(_watch3.name);

                //int currentTime = Convert.ToInt32(Session["timer"]);
                if (currentTime != 2)
                {
                    Session.Add("timer", 2);
                    Timer1.Enabled = true;
                    //InitTimer(3); // or whatever initial value is
                    int minutes = (int)Session["timer"];
                    Label5.Text = minutes.ToString() + " minutes left to BID";
                }

                _label2.Text = "\n" + _watch.description + " Current highest bid: £" + _watch.highestBid;
                label4.Text = "\n" + _watch2.description + " Current highest bid: £" + _watch2.highestBid;
                label6.Text =  "\n" + _watch3.description + " Current highest bid: £" + _watch3.highestBid;
            }
        }


        protected void bid_Click(object sender, EventArgs e)
        {
            if (bidAmount.IsValid)
            {


                switch (ListBox1.SelectedValue)
                {

                    case ("Rolex"):

                        Item _watch = Session["_watch"] as Item;

                        if (double.Parse(inputB.Text) > _watch.yourBid) {
                            _watch.yourBid = double.Parse(inputB.Text);

                        }
                        else
                        {
                            Label1.Text = "You have not increase your current bid for this item please try again";
                            return;
                        }
                        
                        if (_watch.yourBid > _watch.highestBid)
                        {
                            _watch.highestBid = _watch.yourBid;

                                Label1.Text = " Your current bid of £" + _watch.yourBid + " for the " + _watch.description + " has just been submitted you are the current HIGHEST Bidder";

                                _label2.Text = _watch.description + " Current highest bid: £" + _watch.highestBid;
                        }

                        else
                        {

                            Label1.Text = " Your current bid of £" + _watch.yourBid + " for the " + _watch.description + " has just been submitted you are NOT the highest bidder.";
                        }
                        

                        return;


                    case ("Chanel"):

                        Item _watch2 = Session["_watch2"] as Item;


                        if (double.Parse(inputB.Text) > _watch2.yourBid)
                        {
                            _watch2.yourBid = double.Parse(inputB.Text);

                        }
                        else
                        {
                            Label1.Text = "You have not increase your current bid for this item please try again";
                            return;
                        }


                        if (_watch2.yourBid > _watch2.highestBid)
                        {
                            _watch2.highestBid = _watch2.yourBid;

                            Label1.Text = "Your current bid of £" + _watch2.yourBid + " for the " + _watch2.description + " has just been submitted you are the current HIGHEST Bidder";

                            label4.Text = _watch2.description + " Current highest bid: £" + _watch2.highestBid;

                        }
                        else
                        {

                            Label1.Text = " Your current bid of £" + _watch2.yourBid + " for the " + _watch2.description + " has just been submitted you are NOT the highest bidder.";
                        }


                        return;

                    case ("Omega"):

                        Item _watch3 = Session["_watch3"] as Item;

                        if (double.Parse(inputB.Text) > _watch3.yourBid)
                        {
                            _watch3.yourBid = double.Parse(inputB.Text);

                        }
                        else
                        {
                            Label1.Text = "You have not increase your current bid for this item please try again";
                            return;
                        }


                        if (_watch3.yourBid > _watch3.highestBid)
                        {
                            _watch3.highestBid = _watch3.yourBid;


                            Label1.Text = "Your current bid of £" + _watch3.yourBid + " for the " + _watch3.description + " has been submitted you are the current HIGHEST bidder";

                            label6.Text = _watch3.description + " Current highest bid: £" + _watch3.highestBid;

                        }

                        else
                        {

                            Label1.Text = " Your current bid of £" + _watch3.yourBid + " for the " + _watch3.description + " has just been submitted you are NOT the highest bidder.";
                        }

                        return;
                }
            }

            else
            {
                Label1.Text = "Please Enter in Currency Format £x.xx";
            }
        }
        
        protected void Timer1_Tick(object sender, EventArgs e)
        {

            int minutes = (int)Session["timer"];
            minutes--;
            if (minutes > 0)
            {
                Session["timer"] = minutes;
                Label5.Text = minutes.ToString() + " minute left to BID";

            }
            else if (minutes == 0)
            {
                Timer1.Enabled = false;
                Timer2.Enabled = false;
                bid.Enabled = false;
                Label5.Text = "The Auction has now closed Thanks";
                Item _watch = Session["_watch"] as Item;
                Item _watch2 = Session["_watch2"] as Item;
                Item _watch3 = Session["_watch3"] as Item;

                if (_watch.yourBid == _watch.highestBid)
                {
                    EndAuction.ForeColor = System.Drawing.Color.DimGray;
                    EndAuction.Text = "Congrats your bid of £" +_watch.yourBid + " was the winning BID for the Vintage Rolex Oyster Perpetual";
                    Panel1.BackColor = System.Drawing.Color.LightGoldenrodYellow;


                }

                if (_watch2.yourBid == _watch2.highestBid)
                {
                    EndAuction.ForeColor = System.Drawing.Color.Fuchsia;
                    EndAuction1.Text = "Congrats your bid of £" + _watch2.yourBid + " was the winning BID for the Chanel J12 White Unisex Watch";
                    Panel1.BackColor = System.Drawing.Color.LightGoldenrodYellow;

                }

                if (_watch3.yourBid == _watch3.highestBid)
                {
                    EndAuction.ForeColor = System.Drawing.Color.DimGray;
                    EndAuction2.Text = "Congrats your bid of £" + _watch3.yourBid + " was the winning BID for the Omega SeaMaster";
                    Panel1.BackColor = System.Drawing.Color.LightGoldenrodYellow;

                }

                else if(_watch.yourBid < _watch.highestBid && _watch2.yourBid < _watch2.highestBid && _watch3.yourBid < _watch3.highestBid)
                {
                    EndAuction3.ForeColor = System.Drawing.Color.DimGray;
                    EndAuction3.Text = "Unfortunately you were outbidded this time!!";

                }

            }

        }

        protected void Timer2_Tick(object sender, EventArgs e)
        {
            
            Item _watch = Session["_Watch"] as Item;
            Item _watch2 = Session["_watch2"] as Item;
            Item _watch3 = Session["_watch3"] as Item;
            Random random = new Random();

                int randomValue = random.Next(1000, 3000);
                int randomValue2 = random.Next(3000, 5000);
                int randomValue3 = random.Next(25000, 60000);
                _watch.currentBid = randomValue;
                _watch2.currentBid = randomValue2;
                _watch3.currentBid = randomValue3;

            if (_watch.currentBid > _watch.highestBid)
            {
                _watch.highestBid = _watch.currentBid;
                _label2.Text = _watch.description + " Current highest bid : £" + _watch.highestBid;
            }

            if (_watch2.currentBid > _watch2.highestBid)
            {
                _watch2.highestBid = _watch2.currentBid;
                label4.Text = _watch2.description + " Current highest bid: £" + _watch2.highestBid;
            }

            if (_watch3.currentBid > _watch3.highestBid)
            {
                _watch3.highestBid = _watch3.currentBid;
                label6.Text = _watch3.description + " Current highest bid: £" + _watch3.highestBid;
            }

        }
    }

}




//static string Populate(List<Item> newAuction)
//{
//    string name = "";
//    List<string> names = new List<string>();

//    foreach (Item i in newAuction)
//    {
//        names.Add(i.name);
//    }

//    name = names.First();
//    return name;

//}