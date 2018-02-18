'use strict';

class PlayedCards {
    constructor(card1, card2) {
        this.card1 = card1;
        this.card2 = card2;
    }

    clear() {
        this.card1 = '';
        this.card2 = '';
    }    
}

export default PlayedCards;