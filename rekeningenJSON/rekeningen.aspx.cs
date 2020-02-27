using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;


namespace rekeningenJSON
{

    public partial class rekeningen : System.Web.UI.Page
    {

        protected void Page_Load(Object sender, EventArgs e)
        {

            if (kzeJrMndVan.Items.Count == 0)
            {
                FillVanTot(); FillVanNaar(); FillType();
                kzeJrMndVan.SelectedIndex = 0;
                kzeJrMndTot.SelectedIndex = 0;
            }
            //ToonPeriode();
        }


        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //ToonPeriode();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Attaching one onclick event for the entire row, so that it will
                // fire SelectedIndexChanged, while we click anywhere on the row.
                e.Row.Attributes["onclick"] =
                  ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";


                if (e.Row.RowIndex >= 0)
                {
                    e.Row.Cells[4].Text = Convert.ToDecimal(e.Row.Cells[4].Text).ToString("### ##0.00");
                    e.Row.Cells[5].Text = Convert.ToDecimal(e.Row.Cells[5].Text).ToString("### ### ##0");

                }
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            }
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    row.BackColor = System.Drawing.Color.DarkGray;
                    row.Font.Bold = true;
                    row.ToolTip = string.Empty;

                    nrrek.Text = row.Cells[1].Text;
                    txtrek.Text = row.Cells[2].Text;

                    row.ToolTip = "Selected record.";
                    //ToonSQLinGrid3(" SELECT id, jrnref, jrmnd, van, naar,  cast (bedrag as decimal) as bedrag, typetransfer, beschrijving, opmerking FROM journaal WHERE van=" + nrrek.Text + " OR naar=" + nrrek.Text + " ORDER BY jrmnd ;");
                    //ToonPeriode();

                }
                else
                {
                    //row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Attaching one onclick event for the entire row, so that it will
                // fire SelectedIndexChanged, while we click anywhere on the row.
                e.Row.Attributes["onclick"] =
                  ClientScript.GetPostBackClientHyperlink(this.GridView3, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";

                if (e.Row.RowIndex >= 0)
                {
                    e.Row.Cells[5].Text = Convert.ToDecimal(e.Row.Cells[5].Text).ToString("### ##0.00");
                }
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            }
        }


        protected void GridView3_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView3.Rows)
            {
                if (row.RowIndex == GridView3.SelectedIndex)
                {
                    row.BackColor = System.Drawing.Color.DarkGray;
                    row.Font.Bold = true;
                    row.ToolTip = string.Empty;

                    id.Text = row.Cells[0].Text;
                    jrnref.Text = row.Cells[1].Text.Replace(@"&nbsp;", " ");
                    jrmnd.Text = row.Cells[2].Text;
                    van.Text = row.Cells[3].Text;
                    naar.Text = row.Cells[4].Text;
                    bedrag.Text = row.Cells[5].Text;
                    typetransfer.Text = row.Cells[6].Text;
                    beschrijving.Text = row.Cells[7].Text;
                    opmerking.Text = row.Cells[8].Text.Trim();

                    row.ToolTip = "Selected record.";
                }
                else
                {
                    //row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }


        protected void ButtonWisJrnl_Click(object sender, EventArgs e)
        {
            //	pgcom.ExecuteSQL("DELETE FROM journaal WHERE id='" + id.Text + "';");
            //	JournaliPage frmMenu = new JournaliPage();
            feedback.Text = "record gewist " + id.Text;
            //   frmMenu.clearManuToekenning();

        }
        protected void ButtonNieuwJrnl_Click(object sender, EventArgs e)
        {
            id.Text = "";
            ButtonSaveJrnl_Click(sender, e);
        }


        protected void ButtonSaveJrnl_Click(object sender, EventArgs e)
        {
            /*
			string Sql = "";
			try
			{

				Int16 Uid = -1;


				string Ujrnref = jrnref.Text;
				string Ujrmnd = jrmnd.Text;
				Int16 Uvan = Convert.ToInt16(van.Text);
				Int16 Unaar = Convert.ToInt16(naar.Text);
				Double Ubedrag = Convert.ToDouble(bedrag.Text.Replace(" ", ""));
				Int16 Utypetransfer = Convert.ToInt16(typetransfer.SelectedValue);
				string Ubeschrijving = beschrijving.Text.ToString();
				string Uopmerking = opmerking.Text;

				if (id.Text == "") // dan is het toevoegen
				{

					Sql = "INSERT INTO public.journaal( jrnref , jrmnd , van, naar , bedrag, typetransfer, beschrijving, opmerking) " +
						" VALUES('" + Ujrnref + "','" + Ujrmnd + "'," + Uvan + "," + Unaar + ", " + Ubedrag + "," + Utypetransfer + ", '" + Ubeschrijving + "' , '" + Uopmerking + "')";
					this.feedback.Text = Sql;
				}
				else // anders is het bijwerken
				{
					Uid = Convert.ToInt16(id.Text);
					Sql = "UPDATE public.journaal " +
						" SET jrnref='" + Ujrnref + "', jrmnd='" + Ujrmnd + "', van=" + Uvan + ", naar=" + Unaar + ", bedrag= " + Ubedrag + ", typetransfer=" + Utypetransfer + ",beschrijving= '" + Ubeschrijving + "' ,opmerking= '" + Uopmerking + "'" +
						" WHERE id=" + Uid + "; ";
					this.feedback.Text = Sql;
				}
				pgcom.ExecuteSQL(Sql);
				id.Text = "";
				//feedback.Text = "record opgeslaan " + id.Text;
			}
			catch (Exception ex)
			{
				this.feedback.Text = this.feedback.Text + "  |   " + ex.Message;
			}
*/

		}




		public void ToonPeriode()
		{
			string sfltr;

		//	pgcom.ExecuteSQL("DELETE FROM kzeJrMnd ;");
		//	pgcom.ExecuteSQL("INSERT INTO kzeJrMnd select '" + kzeJrMndVan.SelectedItem.Value + "',  '" + kzeJrMndTot.SelectedItem.Value + "';");


			sfltr = " (false ";

			if (CheckBox1.Checked)
			{
				sfltr = sfltr + " OR type='1. Banco'";
			}
			if (CheckBox2.Checked)
			{
				sfltr = sfltr + " OR type='2. Termijn'";
			}
			if (CheckBox3.Checked)
			{
				sfltr = sfltr + " OR type='3. Pensioen'";
			}

			ToonSQLinGrid1("SELECT * FROM qrystandopjrmnd WHERE " + sfltr + ");");



			sfltr = "(JrMnd>='" + kzeJrMndVan.SelectedItem.Value + "' AND JrMnd<='" + kzeJrMndTot.SelectedItem.Value + "') AND (false ";

			if (txtrek.Text != null)
			{
				sfltr = sfltr + " OR Van=" + nrrek.Text + " OR Naar=" + nrrek.Text + ") ";
			}
			else
			{
				sfltr = sfltr + ") ";
			}

			ToonSQLinGrid3("SELECT id, jrnref, jrmnd, van, naar,  cast (bedrag as decimal) as bedrag, typetransfer, beschrijving, opmerking FROM public.journaal WHERE " + sfltr + ";");
		}

		protected void FillVanTot()
		{ //Table2.BgColor  = "silver";
          // Get datatabl




            DataTable dtjrmnd = new DataTable();

			//DataTable dtjrmnd = pgcom.SQLtoDataTable("SELECT * FROM qryjmen ORDER BY jrmnd;");
			// Set fields, bind the data
			kzeJrMndVan.DataSource = dtjrmnd;
			kzeJrMndVan.DataTextField = "jrmnd";
			kzeJrMndVan.DataValueField = "jrmnd";
			kzeJrMndVan.DataBind();

		//	dtjrmnd = pgcom.SQLtoDataTable("SELECT * FROM qryjmen ORDER BY jrmnd DESC;");
			kzeJrMndTot.DataSource = dtjrmnd;
			kzeJrMndTot.DataTextField = "jrmnd";
			kzeJrMndTot.DataValueField = "jrmnd";
			kzeJrMndTot.DataBind();

			jrmnd.DataSource = dtjrmnd;
			jrmnd.DataTextField = "jrmnd";
			jrmnd.DataValueField = "jrmnd";
			jrmnd.DataBind();
		}

		protected void FillVanNaar()
		{ //Table2.BgColor  = "silver";
		  // Get datatable
			
            DataTable dtrek = new DataTable();
			//DataTable dtrek = pgcom.SQLtoDataTable("SELECT * FROM trekeningen ORDER BY nr;");
			// Set fields, bind the data
			van.DataSource = dtrek;
			van.DataTextField = "naam";
			van.DataValueField = "nr";
			van.DataBind();

			naar.DataSource = dtrek;
			naar.DataTextField = "naam";
			naar.DataValueField = "nr";
			naar.DataBind();



		}

		protected void FillType()
		{ //Table2.BgColor  = "silver";
		  // Get datatable
			DataTable dtrek = new DataTable();
		//	DataTable dtrek = pgcom.SQLtoDataTable("SELECT * FROM typetransfers ORDER BY id_typetransfer;");
			// Set fields, bind the data
			typetransfer.DataSource = dtrek;
			typetransfer.DataTextField = "typetransfer";
			typetransfer.DataValueField = "id_typetransfer";
			typetransfer.DataBind();
		}

		protected void ToonSQLinGrid1(string stringSQL)
		{
			// feedback.Text = stringSQL;
		//	GridView1.DataSource = pgcom.SQLtoDataTable(stringSQL);
			GridView1.DataBind();
		}

		protected void ToonSQLinGrid3(string stringSQL)
		{

		//	GridView3.DataSource = pgcom.SQLtoDataTable(stringSQL);
			GridView3.DataBind();
		}
		protected void ButtonTerug_Click(object sender, EventArgs e)
		{
			Response.Redirect("http://localhost:8080/Journali.aspx");
		}


		protected void ButtonJSON_Click(object sender, EventArgs e)
		{
			/*
            DataTable dtrek = pgcom.SQLtoDataTable("SELECT * FROM trekeningen ;");
            string JSONstring = DataTableToJSONWithStringBuilder(dtrek);
            System.IO.File.WriteAllText("/home/geert/Documenten/javascript/rekeningen/trekeningen.json", JSONstring);

            dtrek = pgcom.SQLtoDataTable("SELECT * FROM journaal ;");
            JSONstring = DataTableToJSONWithStringBuilder(dtrek);
            System.IO.File.WriteAllText("/home/geert/Documenten/javascript/rekeningen/journaal.json", JSONstring);

            dtrek = pgcom.SQLtoDataTable("SELECT * FROM qryjmen ;");
            JSONstring = DataTableToJSONWithStringBuilder(dtrek);
            System.IO.File.WriteAllText("/home/geert/Documenten/javascript/rekeningen/qryjmen.json", JSONstring);

            dtrek = pgcom.SQLtoDataTable("SELECT * FROM typetransfers ;");
            JSONstring = DataTableToJSONWithStringBuilder(dtrek);
            System.IO.File.WriteAllText("/home/geert/Documenten/javascript/rekeningen/typetransfers.json", JSONstring);

			DataTable dtrek = pgcom.SQLtoDataTable("SELECT * FROM jaren ;");
			string JSONstring = DataTableToJSONWithStringBuilder(dtrek);
			System.IO.File.WriteAllText("/home/geert/Documenten/javascript/rekeningen/jaren.json", JSONstring);

			dtrek = pgcom.SQLtoDataTable("SELECT * FROM maanden ;");
			JSONstring = DataTableToJSONWithStringBuilder(dtrek);
			System.IO.File.WriteAllText("/home/geert/Documenten/javascript/rekeningen/maanden.json", JSONstring);



		}


		public string DataTableToJSONWithStringBuilder(DataTable table)
		{
			var JSONString = new StringBuilder();
			if (table.Rows.Count > 0)
			{
				JSONString.Append("[");
				for (int i = 0; i < table.Rows.Count; i++)
				{
					JSONString.Append("{");
					for (int j = 0; j < table.Columns.Count; j++)
					{
						if (j < table.Columns.Count - 1)
						{
							JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
						}
						else if (j == table.Columns.Count - 1)
						{
							JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
						}
					}
					if (i == table.Rows.Count - 1)
					{
						JSONString.Append("}");
					}
					else
					{
						JSONString.Append("},");
					}
				}
				JSONString.Append("]");
			}
			return JSONString.ToString();
		}
*/
        }


    }
}