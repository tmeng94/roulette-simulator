using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private void UpdateRoulette()
    {
        RouletteTable.Rows.Clear();
        TableRow header = new TableRow();
        header.Font.Bold = true;
        header.Cells.Add(new TableCell() { Text = "Prize" });
        header.Cells.Add(new TableCell() { Text = "Type" });
        header.Cells.Add(new TableCell() { Text = "Rarity" });
        RouletteTable.Rows.Add(header);
        foreach (Prize prize in Util.roulette.prizes)
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = prize.item.name });
            row.Cells.Add(new TableCell() { Text = Util.itemTypes[prize.item.type] });
            row.Cells.Add(new TableCell() { Text = prize.item.rarity.ToString() });
            RouletteTable.Rows.Add(row);
        }
    }

    private void UpdateResults()
    {
        ResultTable.Rows.Clear();
        TableRow header = new TableRow();
        header.Font.Bold = true;
        header.Cells.Add(new TableCell() { Text = "Name" });
        header.Cells.Add(new TableCell() { Text = "Type" });
        header.Cells.Add(new TableCell() { Text = "Rarity" });
        header.Cells.Add(new TableCell() { Text = "Count" });
        ResultTable.Rows.Add(header);
        foreach (var result in Util.results.OrderBy(result => result.Key))
        {
            Item item = Util.items[result.Key];
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = item.name });
            row.Cells.Add(new TableCell() { Text = Util.itemTypes[item.type] });
            row.Cells.Add(new TableCell() { Text = item.rarity.ToString() });
            row.Cells.Add(new TableCell() { Text = result.Value.ToString() });
            ResultTable.Rows.Add(row);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.UpdateRoulette();
    }

    protected void SpinButton_Click(object sender, EventArgs e)
    {
        Prompt.Text = Util.SpinRoulette();
        this.UpdateResults();
    }

    protected void ClearButton_Click(object sender, EventArgs e)
    {
        Util.results.Clear();
        this.UpdateResults();
    }
}