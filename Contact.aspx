<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>
  
    </hgroup>

    <section class="contact">
        <header>
            <h3>Phone:</h3>
        </header>
        <p>
            <span class="label">Main:</span>
            <span>91-86999-50608</span>
        </p>
        <p>
            <span class="label">After Hours:</span>
            <span>91-95010-23265</span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Email:</h3>
        </header>
        <p>
            <span class="label">Support:</span>
            <span><a href="mailto:karan.devgan@hotmail.com">karan.devgan@hotmail.com</a></span>
        </p>
        <p>
            <span class="label">General:</span>
            <span><a href="mailto:goindwalia@gmail.com">goindwalia@gmail.com</a></span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Address:</h3>
        </header>
        <p>
            Guru Nanak Dev Engineering College<br />
            Gill Road, Ludhiana
        </p>
    </section>
</asp:Content>