<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebClient.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script>(function () {
    var _fbq = window._fbq || (window._fbq = []);
    if (!_fbq.loaded) {
        var fbds = document.createElement('script');
        fbds.async = true;
        fbds.src = '//connect.facebook.net/en_US/fbds.js';
        var s = document.getElementsByTagName('script')[0];
        s.parentNode.insertBefore(fbds, s);
        _fbq.loaded = true;
    }
    _fbq.push(['addPixelId', '546284355523823']);
})();
        window._fbq = window._fbq || [];
        window._fbq.push(['track', 'PixelInitialized', {}]);
    </script>
    <noscript><img height="1" width="1" alt="" style="display:none" src="https://www.facebook.com/tr?id=546284355523823&amp;ev=PixelInitialized" /></noscript>


    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Button ID="BT_getTargetAudienceFromFaceBook" runat="server" OnClick="BT_GetTragetAudiences" Text="Get Target Audieces From FaceBook" />

            <br />
            <br />
            <asp:Label ID="LBL_Products" runat="server"></asp:Label>
        </div>
        <div>
            <br />
            <br />
            <asp:Label ID="LBL_getTargetAuidence" runat="server"></asp:Label>
        </div>

        <br />
        <br />
        <div>
            <asp:GridView ID="gvPerson" runat="server" AutoGenerateColumns="False" BackColor="White"
                BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                <RowStyle BackColor="White" ForeColor="#003399" />
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                    <asp:BoundField DataField="orderID" HeaderText="orderID" ReadOnly="True"
                        SortExpression="orderID" />
                    <asp:TemplateField HeaderText="TargetAudienceName" SortExpression="TargetAudienceName">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("TargetAudienceName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("TargetAudienceName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TargetAudienceID" SortExpression="TargetAudienceID">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("TargetAudienceID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("TargetAudienceID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            </asp:GridView>
            <br />
        </div>
        <br />
        <div>
            <asp:Label ID="Label3" runat="server" Text=" Insert new Target audience :"></asp:Label>

            <asp:TextBox ID="TargetAudinceName" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="BT_SaveTragetAudiences" Text="Save Custom Target Audieces in FaceBook" />
               <asp:RadioButtonList ID="RBT_SelectedTAType" runat="server" 
                RepeatDirection="Horizontal" RepeatLayout="Table">
                <asp:ListItem Text="Create Lookalike TargetAudience" Value="LOOKALIKE"></asp:ListItem>
                <asp:ListItem Text="Create Custom TargetAudience" Value="CUSTOM"></asp:ListItem>
            </asp:RadioButtonList> 
        </div>
    </form>
</body>
</html>
