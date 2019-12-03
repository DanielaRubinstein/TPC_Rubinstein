<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PresentacionWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<%--      <div class="row" ID="cards">

    </div>

    <script>
        let respuesta
        let fila = document.querySelector('#cards')
        fetch('<%=ResolveUrl("Chocolate.aspx/listaProductos")%>', {
            method: 'POST',
            body:`{}`,
            headers: { 'Content-Type': 'application/json' }
        })
            .then(response => {
                return response.json()
            })
        then(res => {
            res = res.d
            for (let i = 0; i < res.length; i++) {
                let columna = document.createElement('div')
                columna.classList.Add('col')
                columna.classList.Add('s4')
                let card = document.createElement('div')
                card.classList.add('card')
                let cardImage = document.createElement('div')
                cardImage = document.createElement('card-image')
                let img = document.createElement('img')
                img.src = res[i].Imagen
                let span = document.createElement('span')
                span.classList.add('card-title')
                span.classList.add('black-text')
                span.innerText = res[i].Descripcion
                let btn = document.createElement('div')
                btn.classList.add('btn-floating')
                btn.classList.add('halfway-fab')
                btn.classList.add('waves-effect')
                btn.classList.add('waves-light')
                btn.classList.add('red')
                if (res[i].StockActual == 0) {
                    btn.classList.add('disabled')
                }
                let icono = document.createElement('i')
                icono.classList.add('material-icons')
                icono.innerText = 'shopping_cart'
                btn.appendChild(icono)
                cardImage.appendChild(img)
                cardImage.appendChild(span)
                cardImage.appendChild(btn)
                card.appendChild(cardImage)
                let cardContent = document.createElement('div')
                cardContent.classList.add('card-content')
                let precio = document.createElement('h6')
                precio.innerText = '$' + res[i].PrecioFinal
                if (res[i].StockActual == 0) {
                    let stock = document.createElement('h6')
                    stock.innerText = 'No hay stock'
                    cardContent.appendChild(stock)
                }
                else {
                    cardContent.appendChild(precio)
                }
                card.appendChild(cardContent)
                columna.appendChild(card)
                fila.appendChild(columna)
            }
        })

    </script>--%>


</asp:Content>
