Overview
This assignment must be completed individually to ensure you are meeting all course outcomes. You should not complete this assignment with a group. If you obtain help from a tutor, the tutor should help you understand principles but should not help you answer these problems. It is an honor code violation to obtain answers for these problems from others including using the internet (i.e. sites that allow students to share their solutions).





Instructions
This assignment is meant to simulate the kind of question you might receive in a job interview. It is important for you to understand the problem, develop a quality solution, and communicate it in a clear and professional manner.

You will need to record and upload a short video with your response to the question below. When making your video, please remember the following:

Show your your face.
Speak clearly.
The video should be less than 3 minutes.
The video should be uploaded as a public, but unlisted video, so the grader can see it without permissions. Most students upload to Youtube and submit a link to the video for grading, but you can upload anywhere as long as you submit a link graders can access.





Scenario: Garden Simulator Game
You have been asked to help write a computer game that simulates planting and growing a garden. In this game, the player moves throughout the landscape trying to discover piles of seeds, which can be planted back in a garden space.

There are different kinds of seeds (for example, pumpkins, tomatoes, peas, etc.) and in each pile of seeds there may be different amounts (for example, 10, 25, 100, etc.). When the player picks up a pile of seeds it gets added to their supply basket.

After placing seeds in the supply basket, the player can then plant them. When planting seeds from the supply basket they can only plant the ones that they most recently picked up, until those seeds are all used. So for example, if they picked up a pile of pumpkin seeds, and later a pile of tomato seeds, they would have to plant all of the tomato seeds before they are able to plant the pumpkin seeds. The player cannot plant seeds if their supply basket is empty.

Once seeds have been planted, the player can water and fertilize them in any order they would like. As long as they have sufficient water and fertilizer, plants will continue to grow until they are ready to be harvested. At that point the food can be harvested, or the plant can be left alone, in which case it will eventually turn into a new pile of seeds that can be picked up.





Questions
In your video, provide a response to each of the following questions:
What would be the best data structure to model the behavior of the supply basket? 

Garden Simulator Game

The Best Data Structure: The best data structure for the basket is a Stack, which works like a Pringles can. When you pick up seeds, you place them in from the top using (Push) so if you find pumpkins and then tomatoes, the tomatoes sit on top, blocking the pumpkins. When planting, you can only grab what is right at the top (Pop), meaning you must use all the tomatoes first. Once they are gone, the pumpkins are uncovered and ready to plant!



What is the time complexity of adding new seeds to the supply basket?
Adding Seeds: $O(1)$ TimeWhat this means: It is instantaneous and takes 1 step.Simplified Explanation: Imagine your basket has 100 bags of seeds stacked up inside it. If you find a new bag of Pea seeds, you don't need to dig to the bottom, rearrange the bags, or count them. You just open the lid and drop it right on top. It takes the exact same amount of effort to drop a bag into an empty basket as it does to drop it into a full one.

What is the time complexity of removing seeds from the supply basket?
Removing Seeds: $O(1)$ TimeWhat this means: It is also instantaneous and takes 1 step.Simplified Explanation: When you want to plant a seed, you don't look through the whole basket. You just grab the bag sitting right at the very top. Because the computer always knows exactly where the top bag is, it can grab it instantly without searching.


What is the time complexity of checking to see if the supply basket is empty?
Checking if the Basket is Empty: $O(1)$ TimeWhat this means: It is instantaneous and takes 1 step.Simplified Explanation: To see if you're out of seeds, the computer doesn't need to count every slot in the basket. It just looks at the very top of the pile. If there is nothing there, the basket is empty. It's a quick, single glance!In short, a Stack is perfect here because it forces that "last picked up, first used" rule automatically, and it is incredibly fast ($O(1)$) because the computer only ever cares about the very top item!