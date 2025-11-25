document.addEventListener("DOMContentLoaded", () => {

    function attachValidation(form, fields, validators) {
        const showError = (field, message) => {
            const input = form.elements[field];
            const feedback =
                form.querySelector(`div.invalid-feedback[data-valmsg-for="${field}"]`) ||
                form.querySelector(`span[data-valmsg-for="${field}"]`);
            if (!input || !feedback) return;

            if (message) {
                input.classList.add('is-invalid');
                input.classList.remove('is-valid');
                feedback.textContent = message;
            } else {
                input.classList.remove('is-invalid');
                input.classList.add('is-valid');
                feedback.textContent = '';
            }
        };

        const validateField = field => {
            const input = form.elements[field];
            if (!input) return false;
            const val = (input.value ?? '').trim();
            const msg = validators[field](val);
            showError(field, msg);
            return !msg;
        };

        const validateForm = () => fields.map(validateField).every(Boolean);

        fields.forEach(f => {
            const el = form.elements[f];
            if (!el) return;
            const handler = () => validateField(f);
            el.addEventListener('input', handler);
            el.addEventListener('blur', handler);
        });

        form.addEventListener('submit', e => {
            if (!validateForm()) e.preventDefault();
        });
    }

    
    (() => {
        const form = document.querySelector('#DepartmentManagerForm');
        if (!form) return;

        const fields = ['DepartmentManager.PersonName', 'DepartmentManager.Birthday', 'DepartmentManager.PersonUser'];
        const validators = {
            'DepartmentManager.PersonName': v => {
                if (!v) return 'Manager name is required';
                if (v.length < 3 || v.length > 50) return 'Name must be between 3 and 50 characters';
                return '';
            },
            'DepartmentManager.Birthday': v => !v ? 'Birthday is required' : '',
            'DepartmentManager.PersonUser': v => {
                if (!v) return 'Email/username is required';
                const regex = /^[^@\s]+@[^@\s]+\.[^@\s]+$/;
                if (!regex.test(v)) return 'Must be a valid email format';
                return '';
            }
        };
        attachValidation(form, fields, validators);
    })();

    
    (() => {
        const form = document.querySelector('#ClubLeaderForm');
        if (!form) return;

        const fields = ['ClubLeader.PersonName', 'ClubLeader.Birthday', 'ClubLeader.PersonUser'];
        const validators = {
            'ClubLeader.PersonName': v => {
                if (!v) return 'Leader name is required';
                if (v.length < 3 || v.length > 50) return 'Name must be between 3 and 50 characters';
                return '';
            },
            'ClubLeader.Birthday': v => !v ? 'Birthday is required' : '',
            'ClubLeader.PersonUser': v => {
                if (!v) return 'Email/username is required';
                const regex = /^[^@\s]+@[^@\s]+\.[^@\s]+$/;
                if (!regex.test(v)) return 'Must be a valid email format';
                return '';
            }
        };
        attachValidation(form, fields, validators);
    })();

   
    (() => {
        const form = document.querySelector('#StudentForm');
        if (!form) return;

        const fields = ['Student.StudentName', 'Student.Birthday', 'Student.StudentUser'];
        const validators = {
            'Student.StudentName': v => {
                if (!v) return 'Student name is required';
                if (v.length < 3 || v.length > 50) return 'Name must be between 3 and 50 characters';
                return '';
            },
            'Student.Birthday': v => !v ? 'Birthday is required' : '',
            'Student.StudentUser': v => {
                if (!v) return 'Email/username is required';
                const regex = /^[^@\s]+@[^@\s]+\.[^@\s]+$/;
                if (!regex.test(v)) return 'Must be a valid email format';
                return '';
            }
        };
        attachValidation(form, fields, validators);
    })();

    
    (() => {
        const form = document.querySelector('#EditPersonForm');
        if (!form) return;

        const fields = ['PersonName', 'Birthday', 'PersonUser'];
        const validators = {
            PersonName: v => {
                if (!v) return 'Name is required';
                if (v.length < 3 || v.length > 50) return 'Name must be between 3 and 50 characters';
                return '';
            },
            Birthday: v => !v ? 'Birthday is required' : '',
            PersonUser: v => {
                if (!v) return 'Email/username is required';
                const regex = /^[^@\s]+@[^@\s]+\.[^@\s]+$/;
                if (!regex.test(v)) return 'Must be a valid email format';
                return '';
            }
        };
        attachValidation(form, fields, validators);
    })();
});
