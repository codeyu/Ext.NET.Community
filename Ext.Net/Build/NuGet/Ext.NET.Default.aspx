<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<script runat="server">
    protected void Button1_Click(object sender, DirectEventArgs e)
    {
        X.Msg.Notify(new NotificationConfig { 
            Icon  = Icon.Accept,
            Title = "Working",
            Html  = this.TextArea1.Text
        }).Show();
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ext.NET Example</title>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" Theme="Gray" />
        
        <ext:Window 
            runat="server" 
            Title="Welcome to Ext.NET 2.0"
            Height="215"
            Width="350"
            BodyPadding="5"
            DefaultButton="0"
            Layout="AnchorLayout"
            DefaultAnchor="100%">
            <Items>
                <ext:TextArea 
                    ID="TextArea1" 
                    runat="server" 
                    EmptyText=">> Enter a Message Here <<"
                    FieldLabel="Test Message" 
                    Height="85" 
                    />
            </Items>
            <Buttons>
                <ext:Button 
                    runat="server" 
                    Text="Submit"
                    Icon="Accept" 
                    OnDirectClick="Button1_Click" 
                    />
            </Buttons>
        </ext:Window>
    </form>
</body>
</html>