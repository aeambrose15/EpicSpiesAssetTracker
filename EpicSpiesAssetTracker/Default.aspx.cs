using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EpicSpiesAssetTracker
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string[] name = new string[0];
                int[] elections = new int[0];
                int[] subterfuge = new int[0];

                ViewState.Add("Name", name);
                ViewState.Add("Elections", elections);
                ViewState.Add("Subterfuge", subterfuge);


            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            string[] name = (string[])ViewState["Name"];
            int[] elections = (int[])ViewState["Elections"];
            int[] subterfuge = (int[])ViewState["Subterfuge"];

            int newLength = name.Length + 1;

            Array.Resize(ref name, newLength);
            Array.Resize(ref elections, newLength);
            Array.Resize(ref subterfuge, newLength);

            int newestItem = name.GetUpperBound(0);
            name[newestItem] = assetNameTextBox.Text;
            elections[newestItem] = int.Parse(electionsTextBox.Text);
            subterfuge[newestItem] = int.Parse(subterfugeTextBox.Text);

            ViewState["Name"] = name;
            ViewState["Elections"] = elections;
            ViewState["Subterfuge"] = subterfuge;

            resultLabel.Text = String.Format("Total Elections Rigged: {0}<br />Average Acts of Subterfuge per Asset: {1:N2}<br />Last Asset you Added: {2}",
                elections.Sum(),
                subterfuge.Average(),
                name[newestItem]);

            assetNameTextBox.Text = "";
            electionsTextBox.Text = "";
            subterfugeTextBox.Text = "";
        
            
        }
    }
}