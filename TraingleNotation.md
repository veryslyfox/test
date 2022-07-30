# Triangle array notation 
## Linear array notation
$$
power \approx f_6(n) \\
1. <a> = a \text{ (release)}\\
2. <a, b> = a^b \text{ (base)}\\
3.<P, 1, Q> = <P, Q> \text{ (annihilation)}\\
4. < a, @, b, c> = <a, @, <a, @, b-1, c>, c - 1>\text{ (recurse)} \\
5. <P, 1, 1, Q, d> = <P, d, Q, d> \text{ (compress)}\\
<3, 3, 3> = <3, 2, <3, 3, 2>> = <3, 2, <3, 2, <3, 3, 1>>> =\\ <3, 2, <3, 2, <3, 3>>> = <3, 2, <3, 2, 27>>
$$
## Linear ranged array notation
$$
power \approx f_\omega(n) \\
6. <a, b>_n = {\underbrace{<a, a...a>_{n-1}}_b}\\
7. < a, @, b, c> = <a, @, <a, @, b-1, c>, c - 1>\text{ (recurse)} \\8. <P>_0 = <P>\\
$$
## Droppary array notation 
$$
power \approx f_{\omega + 1}(n) \\
9. <P>_{a, b, @, c} = <P>_{a, b-1, @, <P>_{a, b, @, c-1}}\\
10. <P>_{@, 1} = <P>_@\\
$$
/ = #
## Droppary primary sepratible array notation
power = $f_{2\omega}(n)$
$$
11. <P>_{a/^d b/^e @/^f c} = <P>_{a/^d b-1/^e @/^f <P>_{a, b, @, c-1}}\\
$$
## Droppary separatible array notation
$$
\text{power} = f_{3 \omega}(n)
$$