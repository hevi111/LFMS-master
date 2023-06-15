<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="About.aspx.cs" Inherits="LFMS.Views.WebForm2" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   

   <div class="jumbotron text-center">
        <h1>Lost and Found Management System</h1>
        <p>Efficiently manage and track lost and found items on campus</p>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h2 class="text-center">About Us</h2>
                <hr>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-8 col-lg-offset-2">
                <p>The Lost and Found Management System is a web and mobile application designed for university students and faculty members to easily report and track lost and found items. This platform addresses the issue of lost items not being returned to their owners due to a lack of a suitable system.</p>
                <p>Our system is fully dynamic and utilizes a variety of technologies such as: ASP.NET, ADO.NET with SQL Server database, LINQ cookies, session management, state view, web services, XML, and AJAX and more to ensure a seamless user experience.</p>
                <p class="text-center"><strong>Our goal is to make the process of reporting and finding lost items as efficient and stress-free as possible for students, faculty members and employees.</strong></p>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                 <img src="https://mir-s3-cdn-cf.behance.net/project_modules/fs/6b652286818829.5da583bcb5e70.jpg" class="img-responsive center-block">
                <h3 class="text-center">Report and Track</h3>
                <p class="text-center">Easily report and track lost and found items with our user-friendly platform.</p>
            </div>
            <div class="col-lg-4">
                <img src="https://dvcdev.utm.my/wp-content/uploads/sites/5/2018/12/alu1.jpg" class="img-responsive center-block">
                <h3 class="text-center">Seamless Experience</h3>
                <p class="text-center">Our dynamic system and use of various technologies ensure a seamless experience for users.</p>
            </div>
            <div class="col-lg-4">
                <img src="https://images.unsplash.com/photo-1517248135467-4c7edcad34c4?ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80" class="img-responsive center-block">
                <h3 class="text-center">Efficient and Stress-Free</h3>
                <p class="text-center">Our goal is to make the process of reporting and finding lost items as efficient and stress-free as possible for students, faculty members, and employees.</p>
            </div>
        </div>
    </div>

     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

</asp:Content>