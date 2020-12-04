# -*- coding: utf-8 -*-
"""
***************************************************************************
@version: python2.7.5 
@author: 'kingdom'
@license: Apache Licence 
@contact: 995350347@qq.com
@site: 
@software: PyCharm
@file: Squish.py
@time: 2017/10/16 16:58
***************************************************************************
"""
import os
import sys

import pygame
from pygame.locals import *

import config
import objects

"This module contains the main Squish logic of the Squish Squish."


class State:
    """
    A generic Squish state class that can handle events and display
    itself on a given surface.
    """

    def __init__(self):
        pass

    def handle(self, event):
        """
        Default event handling only deals with quitting.
        """
        if event.type == QUIT:
            sys.exit()
        if event.type == KEYDOWN and event.key == K_ESCAPE:
            sys.exit()

    def firstDisplay(self, screen):
        """
        Used to display the State for the first time. Fills the screen
        with the background color.
        """
        screen.fill(config.background_color)
        # Remember to call flip, to make the changes visible:
        pygame.display.flip()

    def display(self, screen):
        """
        Used to display the State after it has already been displayed
        once. The default behavior is to do nothing.
        """
        pass


class Level(State):
    """
    A Squish level. Takes care of counting how many weights have been
    dropped, moving the sprites around, and other tasks relating to
    Squish logic.
    """

    def __init__(self, number=1):
        self.number = number
        # How many weights remain to dodge in this level?
        self.remaining = config.weights_per_level

        speed = config.drop_speed
        # One speed_increase added for each level above 1:
        speed += (self.number - 1) * config.speed_increase

        # Create the weight and banana:
        self.weight = objects.Weight(speed)
        self.banana = objects.Banana()
        both = self.weight, self.banana  # This could contain more sprites...
        self.sprites = pygame.sprite.RenderUpdates(both)

    def update(self, game):
        "Updates the Squish state from the previous frame."
        # Update all sprites:
        self.sprites.update()
        # If the banana touches the weight, tell the Squish to switch to
        # a GameOver state:
        if self.banana.touches(self.weight):
            game.nextState = GameOver()
            # Otherwise, if the weight has landed, reset it. If all the
        # weights of this level have been dodged, tell the Squish to
        # switch to a LevelCleared state:
        elif self.weight.landed:
            self.weight.reset()
            self.remaining -= 1
            if self.remaining == 0:
                game.nextState = LevelCleared(self.number)

    def display(self, screen):
        """
        Displays the state after the first display (which simply wipes
        the screen). As opposed to firstDisplay, this method uses
        pygame.display.update with a list of rectangles that need to
        be updated, supplied from self.sprites.draw.
        """
        screen.fill(config.background_color)
        updates = self.sprites.draw(screen)
        pygame.display.update(updates)


class Paused(State):
    """
    A simple, paused Squish state, which may be broken out of by pressing
    either a keyboard key or the mouse button.
    """

    finished = 0  # Has the user ended the pause?
    image = None  # Set this to a file name if you want an image
    text = ''  # Set this to some informative text

    def handle(self, event):
        """
        Handles events by delegating to State (which handles quitting
        in general) and by reacting to key presses and mouse
        clicks. If a key is pressed or the mouse is clicked,
        self.finished is set to true.
        """
        State.handle(self, event)
        if event.type in [MOUSEBUTTONDOWN, KEYDOWN]:
            self.finished = 1

    def update(self, game):
        """
        Update the level. If a key has been pressed or the mouse has
        been clicked (i.e., self.finished is true), tell the Squish to
        move to the state represented by self.nextState() (should be
        implemented by subclasses).
        """
        if self.finished:
            game.nextState = self.nextState()

    def firstDisplay(self, screen):
        """
        The first time the Paused state is displayed, draw the image
        (if any) and render the text.
        """
        # First, clear the screen by filling it with the background color:
        screen.fill(config.background_color)

        # Create a Font object with the default appearance, and specified size:
        font = pygame.font.Font(None, config.font_size)

        # Get the lines of text in self.text, ignoring empty lines at
        # the top or bottom:
        lines = self.text.strip().splitlines()

        # Calculate the height of the text (using font.get_linesize()
        # to get the height of each line of text):
        height = len(lines) * font.get_linesize()

        # Calculate the placement of the text (centered on the screen):
        center, top = screen.get_rect().center  # 为400,300
        top -= height // 2  # 260

        # If there is an image to display...
        if self.image:
            # load it:
            image = pygame.image.load(self.image).convert()
            # get its rect:
            r = image.get_rect()  # 为rect(0,0,166,132)
            # move the text down by half the image height:
            top += r.height // 2  # 326
            # place the image 20 pixels above the text:
            r.midbottom = center, top - 20  # 400,306
            # blit the image to the screen:
            screen.blit(image, r)

        antialias = 1  # Smooth the text
        black = 0, 0, 0  # Render it as black

        # Render all the lines, starting at the calculated top, and
        # move down font.get_linesize() pixels for each line:
        for line in lines:
            text = font.render(line.strip(), antialias, black)
            r = text.get_rect()  # 0,0,312,37
            r.midtop = center, top  # 400,326
            screen.blit(text, r)
            top += font.get_linesize()

            # Display all the changes:
        pygame.display.flip()


class Info(Paused):
    """
    A simple paused state that displays some information about the
    Squish. It is followed by a Level state (the first level).
    """

    nextState = Level
    text = ''''' 
    In this Squish you are a banana, 
    trying to survive a course in 
    self-defense against fruit, where the 
    participants will "defend" themselves 
    against you with a 16 ton weight.'''


class StartUp(Paused):
    """
    A paused state that displays a splash image and a welcome
    message. It is followed by an Info state.
    """

    nextState = Info
    image = config.splash_image
    text = ''''' 
    Welcome to Squish, 
    the Squish of Fruit Self-Defense'''


class LevelCleared(Paused):
    """
    A paused state that informs the user that he or she has cleared a
    given level.  It is followed by the next level state.
    """

    def __init__(self, number):
        self.number = number
        self.text = '''''Level %i cleared 
        Click to start next level''' % self.number

    def nextState(self):
        return Level(self.number + 1)


class GameOver(Paused):
    """
    A state that informs the user that he or she has lost the
    Squish. It is followed by the first level.
    """

    nextState = Level
    text = ''''' 
    Game Over 
    Click to Restart, Esc to Quit'''


class Game:
    """
    A Squish object that takes care of the main event loop, including
    changing between the different Squish states.
    """

    def __init__(self, *args):
        # Get the directory where the Squish and the images are located:
        pth = os.path.abspath(args[0])  # 当前代码文件路径
        mdir = os.path.split(pth)[0]  # 代码目录
        # Move to that directory (so that the images files may be
        # opened later on):
        os.chdir(mdir)  # cd到代码目录
        # Start with no state:
        self.state = None
        # Move to StartUp in the first event loop iteration:
        self.nextState = StartUp()

    def run(self):
        """
        This method sets things in motion. It performs some vital
        initialization tasks, and enters the main event loop.
        """
        pygame.init()  # This is needed to initialize all the pygame modules

        # Decide whether to display the Squish in a window or to use the
        # full screen:
        flag = 0  # Default (window) mode

        if config.full_screen:
            flag = FULLSCREEN  # Full screen mode
        screen_size = config.screen_size
        screen = pygame.display.set_mode(screen_size, flag)

        pygame.display.set_caption('Fruit Self Defense')
        pygame.mouse.set_visible(False)

        # The main loop:
        while True:
            # (1) If nextState has been changed, move to the new state, and
            #     display it (for the first time):
            if self.state != self.nextState:
                self.state = self.nextState
                self.state.firstDisplay(screen)
                # (2) Delegate the event handling to the current state:
            for event in pygame.event.get():
                self.state.handle(event)
                # (3) Update the current state:
            self.state.update(self)
            # (4) Display the current state:
            # time.sleep( 0.5 )
            self.state.display(screen)


if __name__ == '__main__':
    # print(sys.argv)
    game = Game(*sys.argv)
    game.run()
