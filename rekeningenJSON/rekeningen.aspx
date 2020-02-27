<%@ Page Language="C#" Inherits="rekeningenJSON.rekeningen"  EnableEventValidation="False"%>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Rekeningen</title>
                    <link rel="stylesheet" type="text/css" href="eigen.css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">


<table id="Table1"  runat="server">
   
<tr><td>
             <div class="mbox">
            <table>
                <tbody>
                <tr>
                <td> <h1>Rekeningen</h1></td>
                   <td>
                    <asp:Button id="ButtonTerug" CssClass="aspButton" Text="Terug"           OnClick = "ButtonTerug_Click" runat="server"/>
                    <asp:Button id="ButtonJSON" CssClass="aspButton" Text="MaakJSONs"           OnClick = "ButtonJSON_Click" runat="server"/>
                 </td>    
                </tr>
                </tbody>
            </table>
          </div>
</td></tr>

   
<tr><td>
            <table>
                <tr>
                <td>

                            <div class="mbox"><h3> Filter </h3>

                            1. Banco    <asp:CheckBox ID="CheckBox1" runat="server" oncheckedchanged="CheckBox1_CheckedChanged" AutoPostBack="True" Checked="true" />
                            2. Termijn  <asp:CheckBox ID="CheckBox2" runat="server" oncheckedchanged="CheckBox1_CheckedChanged" AutoPostBack="True"/>
                            3. Pensioen <asp:CheckBox ID="CheckBox3" runat="server" oncheckedchanged="CheckBox1_CheckedChanged" AutoPostBack="True"/>
                            <br/>
                                            
                            <table>
                            <tbody>
                                        <tr><td>Vanaf maand</td><td>    <asp:ListBox id="kzeJrMndVan"  Rows="1" AutoPostBack="True" SelectionMode="Single" runat="server"/></td></tr>
                                        <tr><td>Tot maand</td><td>      <asp:ListBox id="kzeJrMndTot"  Rows="1" AutoPostBack="True" SelectionMode="Single"  runat="server"/></td></tr>
                                        <tr><td>Nr</td><td>             <asp:Label id="nrrek" runat="server" /></td></tr>
                                        <tr><td>Rekeningen</td><td>     <asp:Label id="txtrek" runat="server" /></td></tr>
                            </tbody>
                            </table>
                        </div>  
                </td>
                <td> <div class="mbox" style='overflow:scroll; width:98%;height:250px;'>   <h3> Rekening </h3> 
                <asp:GridView ID="GridView1"  OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged" runat="server"></asp:GridView>

                </div></td>
                </tr>
            </table>    
         
</td></tr>
<tr><td>

    <table>
    <tr>
    <td>

                <div class="mbox">
                    <table>
                <tbody>
                <tr>
                 
                <td> <h3> Edit </h3></td>

                <td> 
                   <asp:Button id="ButtonWisJrnl" CssClass="aspButton" Text="Wis"           OnClick = "ButtonWisJrnl_Click" runat="server"/>
                <asp:Button id="ButtonSaveJrnl" CssClass="aspButton" Text="Opslaan"           OnClick = "ButtonSaveJrnl_Click" runat="server"/>
                <asp:Button id="ButtonNieuwJrnl" CssClass="aspButton" Text="Nieuw"           OnClick = "ButtonNieuwJrnl_Click" runat="server"/> 
                    </td>
                   
                </tr>
                </tbody>
            </table>
                                    
        

                <table>
                <tbody>
                <tr><td>id          </td><td> <asp:Label id="id" runat="server" /></td></tr>
                <tr><td>jrnref      </td><td> <asp:TextBox id="jrnref" runat="server" /></td></tr>
                <tr><td>jrmnd       </td><td> <asp:ListBox id="jrmnd"  Rows="1" AutoPostBack="True" SelectionMode="Single" runat="server"/></td></tr>
                <tr><td>van         </td><td> <asp:ListBox id="van"  Rows="1" AutoPostBack="True" SelectionMode="Single" runat="server"/></td></tr>
                <tr><td>naar        </td><td> <asp:ListBox id="naar"  Rows="1" AutoPostBack="True" SelectionMode="Single"  runat="server"/></td></tr>
                <tr><td>bedrag      </td><td> <asp:TextBox id="bedrag" runat="server" /></td></tr>
                <tr><td>typetransfer</td><td> <asp:ListBox id="typetransfer"  Rows="1" AutoPostBack="True" SelectionMode="Single"  runat="server"/></td></tr>
                <tr><td>beschrijving</td><td> <asp:TextBox id="beschrijving" runat="server" /></td></tr>
                <tr><td>opmerking   </td><td> <asp:TextBox id="opmerking" TextMode="MultiLine" runat="server" /></td></tr>
                </tbody>
                </table>

            </div>
    </td>
    <td>
            <div class="mbox" style='overflow:scroll; width:99% ;height:300px;'> 
                                    
                <h2>Journaal</h2>
                                        
              <asp:GridView ID="GridView3"  OnRowDataBound="GridView3_RowDataBound" OnSelectedIndexChanged="GridView3_OnSelectedIndexChanged" runat="server"></asp:GridView>
              </div>
    </td>
    </tr>
    </table>    

</td></tr>                              
<tr><td>
    <asp:TextBox CssClass="feedbacktxt" id="feedback" runat="server" /> 

</td> </tr>
        
</table>
</form>
</body>
</html>

