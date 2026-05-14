mergeInto(LibraryManager.library, {
    HasWindowFunctions: function() {
        if (typeof window !== 'undefined' &&
            typeof window.NextButton === 'function' &&
            typeof window.BackButton === 'function') {
            return 1;
        }
        return 0;
    },

    NextButton: function() {
        if (typeof window !== 'undefined' &&
            typeof window.NextButton === 'function') {
            window.NextButton();
        } else {
            console.log("WebBridge: window.NextButton not found");
        }
    },

    BackButton: function() {
        if (typeof window !== 'undefined' &&
            typeof window.BackButton === 'function') {
            window.BackButton();
        } else {
            console.log("WebBridge: window.BackButton not found");
        }
    }
});
