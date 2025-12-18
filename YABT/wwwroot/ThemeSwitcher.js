window.toggleTheme = function () {
    const html = document.documentElement;
    const current = html.getAttribute("data-bs-theme") || "light";
    const next = current === "dark" ? "light" : "dark";

    html.setAttribute("data-bs-theme", next);
    localStorage.setItem("theme", next);
};

window.applyStoredTheme = function () {
    const stored = localStorage.getItem("theme");
    const theme = stored ?? "light";
    document.documentElement.setAttribute("data-bs-theme", theme);
};

//use var theme = await JS.InvokeAsync<string>("getTheme"); to get current theme
window.getTheme = () => document.documentElement.getAttribute("data-bs-theme");

window.checkUserLoggedIn = function () {
    const userId = localStorage.getItem("YABTUserId");
    const path = location.pathname.toLowerCase();

    if ((!userId || userId.length == 0) && path !== "/login" && path !== "/register") {
        location.replace("/login");
    }
    else if ((userId && userId.length != 0) && (path == "/register" || path == "/login")) {
        location.replace("/");
    }
}