W03 Learning Activity: Articulating Answers to Technical Questions
Overview
In the previous weeks, you have started to get some experience responding to potential job interview questions. This learning activity will give you some additional suggestions on ways to articulate your technical answers clearly.

Interview Questions
It can feel intimidating, but most interviews that relate to software engineering will require us to answer technical questions. These questions frequently include questions related to data structures like the following:

How would you describe the performance of a set?
What is hashing and why is it used with a set?
When would you use a set instead of a list?
You want to practice questions that relate the purpose, behavior, and performance of a data structure. Your responses should be concise, lasting perhaps no more than 30 seconds. Often, these questions are asked within the context of a problem to be solved. In your group practice and individual assignment this week, you will be asked to both respond to "how" you would solve the problem and then, you will actually solve the problem by writing code.

Frequently, the interviewer is more interested in your thought process of getting to the "how" instead of the actual solution. Even so, it's a valuable exercise to also solve the problems so you are better able to describe the "how" in an actual interview.

Articulating the Answer
When you approach a problem to solve with a limited amount of time to respond, you should consider the following guidance:

Understand the problem being asked. You should not hesitate to ask clarifying questions to avoid assumptions. For example: what is the valid range of numbers? Are duplicates allowed? Will there be invalid data in the collection? These questions serve two purposes. First, they help you to understand the problem and second, they communicate to the interviewer that you are aware of common constraints and errors that can occur in software.
Solve the problem by walking through scenarios. Either verbally or on a whiteboard, explain the process of solving the problem for a simple example without introducing code. The simple examples usually are those in which there are no failure cases or unusual conditions.
Identify software techniques such as data structures that can help solve the problem you are analyzing. Talk out loud about the purposes, behavior, and/or performance of the data structure you are using so that the interviewer can see your decision-making process.
Consider boundary conditions. Think about the situations that might cause problems, such as those where the problem is large or small. For example, consider what happens with a negative number, with no items, duplicates, or any other condition that might cause a problem.
Propose a solution. Start to discuss the scenarios that will cause your solution not to work or which may be less than efficient. Refine your solution as you discuss these scenarios.
Don't worry about getting the answer to the problem completely right. Unlike a college coding assignment, you will likely have much less time to develop a solution in the interview.
Notice that one of the common themes of each of these items is to "think out loud" or in other words talk about the ideas you are considering as you develop your solution. Interviewers are not impressed by candidates that have memorized a solution to a common question that may have been on the internet. This is because they are not looking for the answer to this particular problem, they are looking to see your thought process and how you approach a problem. While you are talking, they are asking themselves, "Is this the kind of person I would like to work with?"

Soft Skills Matter!
As mentioned, throughout the interview process, the interviewer is trying to decide if you are a "good fit" for their team. People generally want to work with others who are curious, kind, and hardworking. They have no interest in working with someone who is rude or arrogant, no matter how smart they are.

Often, if a person does not do well with a technical answer, they may be invited back for another interview at some point in the future. However, if an interviewer says that a person is a "bad cultural fit" for the company, they will never consider this canidate again.

This is one of the reasons BYU-Idaho and this program focus so much on learning to collaborate with others.

Activity Instructions
Consider the following scenario:

Write code to find the first time in a string when a letter is duplicated.

Answer each of the following:

What are possible scenarios to consider? (For example, think of a few strings that you would want to try with your solution.)
What are some data structures that may be useful? And what would their performance be?
What are the boundary conditions that you should consider for this problem?
Outline a possible solution.



Possible scenarios: "abcddef" "abcddeef" "abcdefde". The solution should identify "d" in all cases.
Useful data structures: A Set may be helpful in this case because it does not allow duplicates. Also, it has O(1) insertion and O(1) lookup for membership. If we need to keep track of how many times a letter is repeated, a Map may be helpful. It also has O(1) insertion and lookup.
Boundary conditions: "", "abc", "aaaaaaaaaa", "abB", "ab2(:~", "nñ"
An approach: Create an empty Set. Iterate through the string, for each character encountered, check if it is in the set. If not, add it. If you find one in the set, that is the first duplicate. If you never find one in the set, no duplicates exist.
