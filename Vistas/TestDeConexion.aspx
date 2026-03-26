<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestDeConexion.aspx.cs" Inherits="TuProyecto.Vistas.TestDeConexion" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test de Conexión</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h2>Probar Conexión a la Base de Datos</h2>

            <asp:Button ID="btnProbar" runat="server" Text="Probar Conexión" OnClick="btnProbar_Click" />

            <br /><br />

            <asp:Label ID="lblResultado" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>
