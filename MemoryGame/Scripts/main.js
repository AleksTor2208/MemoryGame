var images = document.getElementsByClassName("Images")[0];
var imagesVal = images.getElementsByTagName("img");
var imagesLength = images.getElementsByTagName("img").length;
alert(imagesLength);




//define crucial game elements
// ----------------------------------------------------------
//var player1 = new Player("Player1", 0);
//var player2 = new Player("Player2", 0);
//var PlayedCardsArray = [];
//var CardsQuant = 28;
//var game = new Game(PlayedCardsArray, player1, CardsQuant);
// ----------------------------------------------------------

//for (var i = 0; i < imagesLength; i++) {
//    imagesVal[i].addEventListener('click', function () {
//        game.addChosenCard(this.id);
//    })
//}

class Game {
    constructor(playedCards, currPlayer, cardsQuant) {
        this.playedCards = playedCards;
        this.currPlayer = currPlayer;
        this.cardsQuant = cardsQuant;
    }

    addChosenCard(id) {
        alert(id);
    }


    switchPlayers(player1, player2) {
        if (this.currPlayer == player1) {
            currPlayer = player2;
        } else {
            currPlayer = player1;
        }
    }
}

class PlayedCards {
    constructor(card, card2) {
        this.card1 = card1;
        this.card2 = card2;
    }
}
