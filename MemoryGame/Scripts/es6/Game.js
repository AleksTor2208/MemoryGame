'use strict';

class Game {
    constructor(playedCards, currentPlayer, secPlayer, cardsQ) {
        this.playedCards = playedCards;
        this.currentPlayer = currentPlayer;
        this.secPlayer = secPlayer;
        this.cardsQ = cardsQ;
    }

    startGame() {
        alert('GAME STARTED!');
    }

    addChosenCard(id) {
        alert(id);
        //var images = document.getElementsByClassName("Images")[0];
        var currCard = document.getElementById(id);
        if (this.playedCards.card1 == '') {
            this.playedCards.card2 = currCard;
        }
        else {
            this.playedCards.card1 = currCard;   
        }        
    }

    switchPlayers(secondPlayer) {
        if (this.currentPlayer != secondPlayer) {
            this.currentPlayer = secondPlayer;
        }
    }

    checkCardsEqual() {
        return this.playedCards.card1 === this.playedCards.card2;
    }

    hideEqualCards(card1, card2) {
        //implement hiding
    }

    subtractCardsQ() {
        this.CardsQ -= 2;
    }

    NoCardsLeft() {
        this.CardsQ == 0;        
    }
}

export default Game;