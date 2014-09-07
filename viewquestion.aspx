<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="viewquestion.aspx.cs" Inherits="viewquestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <br />
    <br />
    <div id="QuestionDiv" style="margin-left: 10px; margin-right: 10px; width: 98%">
        <p style="margin: 0px 0px 0px 0px; color: red; font-size: large; font-weight: 600"><%# Question %></p>
        <br />
        <div>
            <div style="float: left;">
                <p style="margin: 0px 0px 0px 0px">
                    <b>Asked By &nbsp;&nbsp;: </b><%# Author %>

                    <span style="margin: 0px 0px 0px 150px">
                        <b>Posted On : </b><%# PostedTime %>
                    </span>

                    <span style="margin: 0px 0px 0px 150px">
                        <b>Views : </b><%# Views %>
                    </span>
                </p>
            </div>
        </div>
    </div>
    <br />
    <hr style="height: 2px; background-color: black" />

    <%-------------------------------------------------------------%>
    <%--This View Shows the answers which are marked as solutions--%>
    <%-------------------------------------------------------------%>
    <div id="SolutionsDiv" style="margin: 10px 10px 10px 10px; width: 98%" runat="server">
        <h3 style="margin: 0px 0px 0px 0px; color: saddlebrown">Solutions :</h3>
        <br />
        <asp:MultiView ID="solutionsView" runat="server">
            <asp:View ID="all" runat="server">
                <asp:Repeater ID="Repeater3" runat="server">
                    <ItemTemplate>
                        <div style="margin: 10px 0px 10px 0px;">
                            <p style="margin: 10px 10px 10px 10px; font-size: medium"><%# Eval("Answer") %></p>

                            <p style="margin: 0px 0px 0px 0px; float: left">
                                <b>Posted By :</b> <%# Eval("Author") %>
                                <b>Posted On :</b> <%# Eval("PostedTime") %>
                            </p>

                        </div>
                        <br />
                        <br />
                        <br />
                        <hr style="background-color: black; height: 1px" />
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </asp:View>

            <asp:View ID="creator" runat="server">
                <asp:Repeater ID="Repeater4" runat="server" OnItemCommand="Repeater4_ItemCommand">
                    <ItemTemplate>
                        <div style="margin: 10px 0px 10px 0px;">
                            <p style="margin: 10px 10px 10px 10px; font-size: medium"><%# Eval("Answer") %></p>

                            <p style="margin: 0px 0px 0px 0px; float: left">
                                <b>Posted By :</b> <%# Eval("Author") %>
                                <b>Posted On :</b> <%# Eval("PostedTime") %>
                            </p>


                            <p style="margin: 0px 0px 0px 0px; float: right">
                                <asp:LinkButton runat="server" ID="markSolution" CssClass="LabelLink"
                                    Text="Unmark As Solution" CausesValidation="false"
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "AnswerID") %>' />
                            </p>

                        </div>
                        <br />
                        <br />
                        <br />
                        <hr style="background-color: black; height: 1px" />
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </asp:View>
        </asp:MultiView>
    </div>

    <br />

    <div id="AddAnswerDiv" runat="server" style="margin-left: 10px; width: 98%">
        <h5>Add An Answer :</h5>

        <asp:MultiView ID="AddAnswerView" runat="server">
            <asp:View runat="server" ID="NoUserView">
                <p class="message-info">
                    You must be logged in to Add Answer
                    <br />
                    Please
                    <asp:HyperLink ID="ClickHere" runat="server" Text="Click Here" />
                    to log in.
                </p>
            </asp:View>

            <asp:View runat="server" ID="LoggedUserView">
                <asp:TextBox ID="AnswerBox" Width="40%" TextMode="MultiLine" runat="server" Height="50px" />
                <asp:RequiredFieldValidator runat="server" ID="AnswerValidator" ErrorMessage="This Field is required"
                    ControlToValidate="AnswerBox" CssClass="field-validation-error" />
                <br />
                <asp:Button runat="server" ID="AnswerButton" Text="Post Answer" OnClick="AnswerButton_Click" />
            </asp:View>
        </asp:MultiView>
    </div>

    <br />

    <%-----------------------------------------------------------------%>
    <%--This View Shows the answers which are not marked as solutions--%>
    <%-----------------------------------------------------------------%>
    <div id="AnswersDiv" style="margin-left: 10px; width: 98%" runat="server">
        <h3 style="margin: 0px 0px 0px 0px; color: saddlebrown">Other Answers :</h3>
        <br />
        <asp:MultiView ID="answersView" runat="server">
            <asp:View ID="allUsers" runat="server">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div style="margin: 10px 0px 10px 0px;">
                            <p style="margin: 10px 10px 10px 10px; font-size: medium"><%# Eval("Answer") %></p>
                            <p style="margin: 0px 0px 0px 0px; float: left">
                                <b>Posted By :</b> <%# Eval("Author") %>
                                <b>Posted On :</b> <%# Eval("PostedTime") %>
                            </p>
                        </div>
                        <br />
                        <br />
                        <br />
                        <hr style="background-color: black; height: 1px" />
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </asp:View>

            <asp:View ID="postedUser" runat="server">
                <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">
                    <ItemTemplate>
                        <div style="margin: 10px 0px 10px 0px;">
                            <p style="margin: 10px 10px 10px 10px; font-size: medium"><%# Eval("Answer") %></p>

                            <p style="margin: 0px 0px 0px 0px; float: left">
                                <b>Posted By :</b> <%# Eval("Author") %>
                                <b>Posted On :</b> <%# Eval("PostedTime") %>
                            </p>


                            <p style="margin: 0px 0px 0px 0px; float: right">
                                <asp:LinkButton runat="server" ID="markSolution" CssClass="LabelLink"
                                    Text="Mark As Solution" CausesValidation="false"
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "AnswerID") %>' />
                            </p>

                        </div>
                        <br />
                        <br />
                        <br />
                        <hr style="background-color: black; height: 1px" />
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>

