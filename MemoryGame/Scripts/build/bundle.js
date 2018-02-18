/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, {
/******/ 				configurable: false,
/******/ 				enumerable: true,
/******/ 				get: getter
/******/ 			});
/******/ 		}
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = 0);
/******/ })
/************************************************************************/
/******/ ([
/* 0 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(1);


/***/ }),
/* 1 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";


var _Player = __webpack_require__(2);

var _Player2 = _interopRequireDefault(_Player);

var _Game = __webpack_require__(3);

var _Game2 = _interopRequireDefault(_Game);

var _PlayedCards = __webpack_require__(4);

var _PlayedCards2 = _interopRequireDefault(_PlayedCards);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

var images = document.getElementsByClassName("Images")[0];
var imagesVal = images.getElementsByTagName("img");
var imagesLength = images.getElementsByTagName("img").length;

var player1 = new _Player2.default('player1', 0);
var player2 = new _Player2.default('player2', 0);
var playedCards = new _PlayedCards2.default('', '');

var game = new _Game2.default(playedCards, player1, player2, imagesLength);

// START GAME
game.startGame();
var playing = true;

while (playing) {

    for (var i = 0; i < imagesLength; i++) {
        imagesVal[i].addEventListener('click', function () {
            game.addChosenCard(this.id);
        });
    }

    if (playedCards.card1 != '' && playedCards.card2 != '') {
        if (game.checkCardsEqual()) {
            alert('cards are equal!');
        }
    }
}

function ChooseCards() {

    if (playedCards.card1 != '' && playedCards.card2 != '') {
        return;
    }
}

for (var i = 0; i < imagesLength; i++) {
    imagesVal[i].addEventListener('click', function () {
        game.addChosenCard(this.id);
        //alert(typeof(this.id));
    });
}

/***/ }),
/* 2 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var Player = function () {
    function Player(name, points) {
        _classCallCheck(this, Player);

        this.name = name;
        this.points = points;
    }

    _createClass(Player, [{
        key: "sayName",
        value: function sayName() {
            console.log("Hi, I'm ${this.name}");
        }
    }]);

    return Player;
}();

exports.default = Player;

/***/ }),
/* 3 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var Game = function () {
    function Game(playedCards, currentPlayer, secPlayer, cardsQ) {
        _classCallCheck(this, Game);

        this.playedCards = playedCards;
        this.currentPlayer = currentPlayer;
        this.secPlayer = secPlayer;
        this.cardsQ = cardsQ;
    }

    _createClass(Game, [{
        key: 'startGame',
        value: function startGame() {
            alert('GAME STARTED!');
        }
    }, {
        key: 'addChosenCard',
        value: function addChosenCard(id) {
            alert(id);
            //var images = document.getElementsByClassName("Images")[0];
            var currCard = document.getElementById(id);
            if (this.playedCards.card1 == '') {
                this.playedCards.card2 = currCard;
            } else {
                this.playedCards.card1 = currCard;
            }
        }
    }, {
        key: 'switchPlayers',
        value: function switchPlayers(secondPlayer) {
            if (this.currentPlayer != secondPlayer) {
                this.currentPlayer = secondPlayer;
            }
        }
    }, {
        key: 'checkCardsEqual',
        value: function checkCardsEqual() {
            return this.playedCards.card1 === this.playedCards.card2;
        }
    }, {
        key: 'hideEqualCards',
        value: function hideEqualCards(card1, card2) {
            //implement hiding
        }
    }, {
        key: 'subtractCardsQ',
        value: function subtractCardsQ() {
            this.CardsQ -= 2;
        }
    }, {
        key: 'NoCardsLeft',
        value: function NoCardsLeft() {
            this.CardsQ == 0;
        }
    }]);

    return Game;
}();

exports.default = Game;

/***/ }),
/* 4 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var PlayedCards = function () {
    function PlayedCards(card1, card2) {
        _classCallCheck(this, PlayedCards);

        this.card1 = card1;
        this.card2 = card2;
    }

    _createClass(PlayedCards, [{
        key: 'clear',
        value: function clear() {
            this.card1 = '';
            this.card2 = '';
        }
    }]);

    return PlayedCards;
}();

exports.default = PlayedCards;

/***/ })
/******/ ]);
//# sourceMappingURL=bundle.js.map