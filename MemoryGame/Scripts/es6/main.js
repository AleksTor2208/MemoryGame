import Player from '../es6/Player.js';
import Game from '../es6/Game.js';
import PlayedCards from '../es6/PlayedCards.js';

var images = document.getElementsByClassName("Images")[0];
var imagesVal = images.getElementsByTagName("img");
var imagesLength = images.getElementsByTagName("img").length;

var player1 = new Player('player1', 0);
var player2 = new Player('player2', 0);
var playedCards = new PlayedCards('', '');

var game = new Game(playedCards, player1, player2, imagesLength)

// START GAME
game.startGame();
var playing = true;

for (var i = 0; i < imagesLength; i++) {
    imagesVal[i].addEventListener('click', function () {
        game.addChosenCard(this.id)
    })
}

while (playing) {

    

    if (playedCards.card1 != '' && playedCards.card2 != '') {
        if (game.checkCardsEqual()) {
            alert('cards are equal!');
        }
    }
    
    break;
}

function ChooseCards() {
    
        if (playedCards.card1 != '' && playedCards.card2 != '') {
            return;
        }
    }





for (var i = 0; i < imagesLength; i++){
    imagesVal[i].addEventListener('click', function () {
        game.addChosenCard(this.id);
        //alert(typeof(this.id));
    })
}



