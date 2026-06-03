window.upskillTheme = {
    storageKey: 'upskill-theme',
    validThemes: ['light', 'dark'],

    getStoredTheme: function () {
        const storedTheme = localStorage.getItem(window.upskillTheme.storageKey);
        return window.upskillTheme.validThemes.includes(storedTheme) ? storedTheme : 'light';
    },

    applyTheme: function (theme) {
        const nextTheme = window.upskillTheme.validThemes.includes(theme) ? theme : 'light';
        document.documentElement.setAttribute('data-theme', nextTheme);
        localStorage.setItem(window.upskillTheme.storageKey, nextTheme);
        return nextTheme;
    },

    toggleTheme: function () {
        const currentTheme = document.documentElement.getAttribute('data-theme') || window.upskillTheme.getStoredTheme();
        return window.upskillTheme.applyTheme(currentTheme === 'dark' ? 'light' : 'dark');
    }
};

(function () {
    window.upskillTheme.applyTheme(window.upskillTheme.getStoredTheme());
})();
