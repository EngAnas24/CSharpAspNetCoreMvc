// Sign in & Sign up
const wrapper = document.querySelector(".wrapper");
const signinLink = document.querySelector(".signin-link");
const signupLink = document.querySelector(".signup-link");

signupLink.addEventListener("click", () => {
  wrapper.classList.add("active");
});

signinLink.addEventListener("click", () => {
  wrapper.classList.remove("active");
});
