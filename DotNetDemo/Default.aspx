<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="width: 80%; margin: auto;">
    <form id="form1" runat="server">
        <div>Try collecting special 2nd-Chance items from duplicate Gems!</div>
        <div>
            <asp:Table ID="RouletteTable" style="width: 600px;" runat="server"></asp:Table>
        </div>
        <div>
            <asp:Button ID="SpinButton" runat="server" Text="Spin" OnClick="SpinButton_Click" />
            <asp:Button ID="ClearButtom" runat="server" Text="Clear" OnClick="ClearButton_Click" />
            <asp:Label id="Prompt" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Table ID="ResultTable" style="width: 600px;" runat="server">
                <%--<asp:TableRow>
                    <asp:TableCell>ID</asp:TableCell>
                    <asp:TableCell>Name</asp:TableCell>
                    <asp:TableCell>Type</asp:TableCell>
                    <asp:TableCell>Rarity</asp:TableCell>
                    <asp:TableCell>Count</asp:TableCell>
                </asp:TableRow>--%>
            </asp:Table>
        </div>
    </form>
</body>
</html>
